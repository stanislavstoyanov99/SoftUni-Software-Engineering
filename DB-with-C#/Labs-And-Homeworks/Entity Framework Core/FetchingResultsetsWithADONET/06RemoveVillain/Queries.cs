namespace _06RemoveVillain
{
    public static class Queries
    {
        public static string TakeVillainId = "SELECT Name FROM Villains WHERE Id = @villainId";

        public static string DeleteVillainFromMinionsVillains = @"DELETE FROM MinionsVillains 
                                                                        WHERE VillainId = @villainId";

        public static string DeleteVillainFromVillains = @"DELETE FROM Villains
                                                                 WHERE Id = @villainId";
    }
}
