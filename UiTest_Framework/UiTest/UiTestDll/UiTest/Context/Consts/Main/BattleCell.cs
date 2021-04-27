namespace Assets.UiTest.Context.Consts
{
    public class BattleCell 
    {
        public static readonly string Id = "battle";
        public readonly StringParam BunkerButton = new StringParam("bunker_button", Id);
        public readonly StringParam SocialActionsFriend = new StringParam("social_actions_friend", Id);
        public readonly StringParam SocialActionsParty = new StringParam("social_actions_party", Id);
        public readonly StringParam SocialClans = new StringParam("social_clans", Id);
        public readonly StringParam BikePerksBar = new StringParam("bike_perks_bar", Id);
    }
}