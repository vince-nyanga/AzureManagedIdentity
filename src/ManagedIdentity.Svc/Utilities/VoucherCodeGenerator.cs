namespace ManagedIdentity.Svc.Utilities
{
    internal static class VoucherCodeGenerator
    {
        private static readonly char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        /// <summary>
        /// Generates a 16 character voucher code
        /// </summary>
        /// <returns></returns>
        internal static string Generate()
        {
            var random = new Random();
            var code = new string(Enumerable.Repeat(_chars, 16)
                .Select(x => x[random.Next(0, _chars.Length - 1)])
                .ToArray());

            return string.Format("{0}-{1}-{2}-{3}",
                code.Substring(0, 4),
                code.Substring(4, 4),
                code.Substring(8, 4),
                code.Substring(12, 4));
        }
    }
}
