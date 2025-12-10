using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Threading.Tasks;

// 👇 alias al tipo correcto
using UaAppConfig = Opc.Ua.ApplicationConfiguration;

namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    internal class Servicio_OPC : IDisposable
    {
        private readonly string _endpointUrl;

        private ApplicationInstance? _application;
        private UaAppConfig? _config;
        private Session? _session;

        public bool IsConnected => _session?.Connected == true;

        public Servicio_OPC(string endpointUrl)
        {
            _endpointUrl = endpointUrl;
        }

        public async Task ConectarAsync()
        {
            _application = new ApplicationInstance
            {
                ApplicationName = "MyClientWinForms",
                ApplicationType = ApplicationType.Client
            };

            // Carga ClientConfig.xml desde la carpeta del .exe
           // _config = await _application.LoadApplicationConfiguration("ClientConfig.xml", false);
            string cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientConfig.xml");
            _config = await _application.LoadApplicationConfiguration(cfgPath, false);


            // Aceptar certificados no confiables (SOLO PRUEBAS)
            _config.CertificateValidator.CertificateValidation += (s, e) =>
            {
                e.Accept = true;
            };

            // 🔴 AQUÍ VA EL CAMBIO IMPORTANTE DE SelectEndpoint 🔴
            // En 1.5.x ya no existe la sobrecarga (string, bool)
            // usamos la versión con configuración + url + seguridad + timeout
            EndpointDescription endpointDescription =
                CoreClientUtils.SelectEndpoint(
                    _config,
                    _endpointUrl,
                    useSecurity: false,
                    discoverTimeout: 15000);

            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(_config);
            ConfiguredEndpoint endpoint =
                new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

            _session = await Session.Create(
                    _config,
                    endpoint,
                    updateBeforeConnect: false,   // 3er parámetro
                    checkDomain: false,           // 4º parámetro NUEVO
                    sessionName: _application.ApplicationName,
                    sessionTimeout: 60000,
                    identity: null,
                    preferredLocales: null);

            if (_session == null || !_session.Connected)
            {
                throw new Exception("No se pudo crear la sesión OPC UA.");
            }
        }

        public async Task<object?> LeerNodoAsync(ushort ns, uint id)
        {
            if (_session == null || !_session.Connected)
                throw new InvalidOperationException("La sesión OPC UA no está conectada.");

            NodeId nodeId = new NodeId(id, ns);
            DataValue dv = await _session.ReadValueAsync(nodeId);
            return dv.Value;
        }

        public async Task<T> LeerNodoAsync<T>(ushort ns, uint id)
        {
            object? value = await LeerNodoAsync(ns, id);

            if (value is T t)
                return t;

            return (T)Convert.ChangeType(value!, typeof(T));
        }

        public void Desconectar()
        {
            if (_session != null)
            {
                try
                {
                    _session.Close();   // warning de obsoleto, pero compila
                }
                catch { }
                finally
                {
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        public void Dispose()
        {
            Desconectar();
        }
    }
}
