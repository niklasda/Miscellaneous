using MbUnit.Framework;
using NBehave.Narrator.Framework;
using NBehave.Spec.MbUnit;

namespace MbUnitDemo.NSpec.Specs
{
    [TestFixture, Theme("Account holder")]
    public class AccountHolderSpecs : SpecBase
    {
        [Test, Story]
        public void Add_account_to_holder()
        {
            var story = new Story("Add account to holder");

            story
                .AsA("account holder")
                .IWant("to add accounts to my portfolio")
                .SoThat("I can access those accounts through the bank");

            Account account = null;
            AccountHolder holder = null;

            story.WithScenario("new account")
                .Given("my account holder is", "Joe", name => holder = new AccountHolder(name))
                .And("a new account with balance", 0, balance => account = new Account(balance))
                .When("the new account is added to the account holder", account,
                      accountToAdd => holder.AddAccount(accountToAdd))
                .Then("the new account should be held by the account holder", holder, account,
                      (accountHolder, accountHeld) => accountHolder.AccountsHeld[0].ShouldEqual(accountHeld))
                ;
        }
    }

}