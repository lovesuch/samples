namespace Kay.Consul
{
    public class ConsulSettings
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务IP
        /// </summary>
        public string ServiceIp { get; set; }

        /// <summary>
        /// 服务端口
        /// </summary>
        public int ServicePort { get; set; }

        /// <summary>
        /// 服务健康检查地址
        /// </summary>
        public string ServiceHealth { get; set; }

        /// <summary>
        /// Consul 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Consul DataCenter
        /// </summary>
        public string DataCenter { get; set; }
    }
}