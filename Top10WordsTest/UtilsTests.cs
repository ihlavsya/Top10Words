using Top10Words;

namespace Top10WordsTest;

[TestFixture]
public class UtilsTests
{
    [Test]
    public void RemoveSpecialCharactersTest()
    {
        var str = "123fjfnfk kjfekfkek;'./.;;. dkmkdkek";
        var expected = "123fjfnfk kjfekfkek dkmkdkek";

        var actual = Utils.RemoveSpecialCharacters(str);

        Assert.That(actual, Is.EqualTo(expected));
    }
}