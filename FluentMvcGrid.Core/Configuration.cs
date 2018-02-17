namespace FluentMvcGrid.Core
{
    public class Configuration
    {
        private BootstrapVersion _bootstrapVersion;
        private WhiteSpace _whiteSpace;

        public Configuration()
        {
            _bootstrapVersion = Core.BootstrapVersion.Bootstrap3;
            _whiteSpace = Core.WhiteSpace.None;
        }

        public Configuration BootstrapVersion(BootstrapVersion value)
        {
            _bootstrapVersion = value;
            return this;
        }

        public Configuration WhiteSpace(WhiteSpace value)
        {
            _whiteSpace = value;
            return this;
        }

        internal BootstrapVersion GetBootstrapVersion()
        {
            return _bootstrapVersion;
        }

        internal WhiteSpace GetWhiteSpace()
        {
            return _whiteSpace;
        }
    }
}