namespace MLZ2025.Core.Tests;

using MLZ2025.Core.Model;
using SQLite;

[TestFixture]
public class SQLiteTests
{

    [Test]
    public void TestGetData()
    {
        if (!Directory.Exists(DatabaseFolder))
        {
            Directory.CreateDirectory(DatabaseFolder);
        }

        var options = new SQLiteConnectionString(DatabasePath, true);
        var connection = new SQLiteConnection(options);

        var tableExists = connection.TableMappings.Any(
            m => m.TableName.Equals(nameof(Address), StringComparison.InvariantCultureIgnoreCase)
        );

        if (!tableExists)
        {
            connection.CreateTable<Address>();
        }
        connection.DeleteAll<Address>();
        

        var addresses = connection.Table<Address>().Count();

        Assert.That(addresses, Is.EqualTo(0));

        var address = new Address
        {
            FirstName = "John",
            LastName = "Doe"
        };
        connection.Insert(address);

        addresses = connection.Table<Address>().Count();

        Assert.That(addresses, Is.EqualTo(1));
    }


    //get the path to the local application data folder
    private static readonly string DatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "addresses.db";
    private static readonly string DatabaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "MLZ2025.Core.Tests";
}

