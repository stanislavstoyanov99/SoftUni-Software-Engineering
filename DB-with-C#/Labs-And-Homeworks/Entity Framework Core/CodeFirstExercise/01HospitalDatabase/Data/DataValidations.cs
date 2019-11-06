namespace P01_HospitalDatabase.Data
{
    public static class DataValidations
    {
        public static class Patient
        {
            public const int MaxNameLength = 50;
            public const int MaxAddressLength = 250;
            public const int MaxEmailLength = 80;
        }

        public static class Visitation
        {
            public const int MaxCommentLength = 250;
        }

        public static class Diagnose
        {
            public const int MaxNameLength = 50;
            public const int MaxCommentsLength = 250;
        }

        public static class Medicament
        {
            public const int MaxNameLength = 50;
        }
    }
}
