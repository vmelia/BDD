using SpecFlowTests.Pages;

namespace SpecFlowTests.StepDefinitions;

[Binding]
public class AddTaskStepDefinitions
{
    private readonly MainPage _page;

    public AddTaskStepDefinitions(MainPage page)
    {
        _page = page;
    }

    [Given(@"I am on the main page")]
    public void GivenIAmOnTheMainPage()
    {
        _page.Displayed.Should().BeTrue();
    }

    [Given(@"I enter a task name containing just spaces")]
    public void GivenIEnterATaskNameContainingJustSpaces()
    {
        _page.EnterTask.SendKeys("    ");
    }

    [Given(@"I enter a task named (.*)")]
    public void GivenIEnterATaskNamed(string taskName)
    {
        _page.EnterTask.SendKeys(taskName);
    }

    [Then(@"Add should be (.*)")]
    public void AddShouldBe(string enabledOrDisabled)
    {
        var enabled = enabledOrDisabled == "enabled";
        _page.Add.Enabled.Should().Be(enabled);
    }

    [Given(@"I choose add")]
    public void GivenIChooseAdd()
    {
        _page.Add.Click();
    }

    [Then(@"the list should show (.*)")]
    public void ThenTheListShouldShow(string taskName)
    {
        var item = _page.TaskListItem;
        item.Text.Should().Be(taskName);
    }
}