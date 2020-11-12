namespace ZenProject.Core
{
    public static class Enums
    {
        /// <summary>
        /// Gender enum
        /// </summary>
        public enum Gender
        {
            male = 1,
            female = 2
        }

        /// <summary>
        /// StaffRoles enum
        /// </summary>
        public enum StaffRoles
        {
            Director,
            Producer,
            Camera,
            Lights,
            Photograpy,
            MakeUp,
            Other
        }

        /// <summary>
        /// TalentRoles enum
        /// </summary>
        public enum TalentRoles
        {
            Model,
            Actor,
            Singer
        }

        /// <summary>
        /// ProjectStatus enum
        /// </summary>
        public enum ProjectStatus
        {
            Planning,
            Paused,
            Canceled,
            InTheMaking,
            Completed
        }

        public enum ProjectForm
        {
            Photography,
            Video
        }
    }
}
