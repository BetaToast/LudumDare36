namespace LD36
{
    public static class SoundNames
    {
        /// *NOTE* Make sure no extensions are on these names - The MonoGame Pipeline builder app handles the actual files, just need the common name

        public static string CowMoo1 = $@"sfx/{nameof(CowMoo1)}";
        public static string VintageButton1 = $@"sfx/{nameof(VintageButton1)}";
        public static string ConfirmBeepy02 = $@"sfx/{nameof(ConfirmBeepy02)}";
    }

    public static class SongNames
    {
        public static string CrystalHunterPreview = $@"musx/{nameof(CrystalHunterPreview)}";
        public static string Morning = $@"musx/{nameof(Morning)}";
    }
}
