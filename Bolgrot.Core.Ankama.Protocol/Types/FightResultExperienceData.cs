namespace Bolgrot.Core.Ankama.Protocol.Types
{
    public class FightResultExperienceData
    {

	    public int experience;
	    public bool showExperience;
	    public int experienceLevelFloor;
	    public bool showExperienceLevelFloor;
	    public int experienceNextLevelFloor;
	    public bool showExperienceNextLevelFloor;
	    public int experienceFightDelta;
	    public bool showExperienceFightDelta;
	    public int experienceForGuild;
	    public bool showExperienceForGuild;
	    public int experienceForMount;
	    public bool showExperienceForMount;
	    public bool isIncarnationExperience;
	    public int rerollExperienceMul;


        public string _type = "FightResultExperienceData";

        public FightResultExperienceData()
        {
        }

        public FightResultExperienceData(int experience, bool showExperience, int experienceLevelFloor, bool showExperienceLevelFloor, int experienceNextLevelFloor, bool showExperienceNextLevelFloor, int experienceFightDelta, bool showExperienceFightDelta, int experienceForGuild, bool showExperienceForGuild, int experienceForMount, bool showExperienceForMount, bool isIncarnationExperience, int rerollExperienceMul)
        {
            this.experience = experience;
            this.showExperience = showExperience;
            this.experienceLevelFloor = experienceLevelFloor;
            this.showExperienceLevelFloor = showExperienceLevelFloor;
            this.experienceNextLevelFloor = experienceNextLevelFloor;
            this.showExperienceNextLevelFloor = showExperienceNextLevelFloor;
            this.experienceFightDelta = experienceFightDelta;
            this.showExperienceFightDelta = showExperienceFightDelta;
            this.experienceForGuild = experienceForGuild;
            this.showExperienceForGuild = showExperienceForGuild;
            this.experienceForMount = experienceForMount;
            this.showExperienceForMount = showExperienceForMount;
            this.isIncarnationExperience = isIncarnationExperience;
            this.rerollExperienceMul = rerollExperienceMul;

        }
    }
}