using SpecFlowTests.Pages;

namespace SpecFlowTests.StepDefinitions;

[Binding]
public class AddTaskStepDefinitions
{
    private readonly MainPage _mainPage;

    public AddTaskStepDefinitions(PageFactory pageFactory)
    {
        _mainPage = (MainPage)pageFactory.CreatePage(nameof(MainPage));
    }

    [Given(@"I am on the main page")]
    public void GivenIAmOnTheMainPage()
    {
        _mainPage.Displayed.Should().BeTrue();
    }

    [Given(@"I enter a task name containing just spaces")]
    public void GivenIEnterATaskNameContainingJustSpaces()
    {
        _mainPage.EnterTask.SendKeys("    ");
    }

    [Given(@"I enter a task named (.*)")]
    public void GivenIEnterATaskNamed(string taskName)
    {
        _mainPage.EnterTask.SendKeys(taskName);
    }

    [Then(@"Add should be (.*)")]
    public void AddShouldBe(string enabledOrDisabled)
    {
        var enabled = enabledOrDisabled == "enabled";
        _mainPage.Add.Enabled.Should().Be(enabled);
    }

    [Given(@"I choose add")]
    public void GivenIChooseAdd()
    {
        _mainPage.Add.Click();
    }

    [Then(@"the list should show (.*)")]
    public void ThenTheListShouldShow(string text)
    {
        foreach (var t in _mainPage.TaskList)
        {
            Console.WriteLine(t.Text);
        }
        _mainPage.TaskList.Should().Contain(x => x.Text == text);
    }
}