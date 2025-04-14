using FluentMigrator;

namespace Todo_Service.Migrations
{
    [Migration(1)]
    public class _0001_Todos : Migration
    {
        public override void Up()
        {
            Create.Table("todos")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("Description").AsCustom("TEXT").Nullable()
                .WithColumn("IsCompleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("Status").AsString(1).WithDefaultValue("A")
                .WithColumn("CreatedAt").AsCustom("TIMESTAMP").WithDefaultValue(SystemMethods.CurrentDateTime);

            Insert.IntoTable("todos").Row(new { UserId = 1, Title = "Buy groceries", Description = "Milk, Bread, Eggs, Cheese", IsCompleted = false });
            Insert.IntoTable("todos").Row(new { UserId = 2, Title = "Finish report", Description = "Complete the sales report by EOD", IsCompleted = false });
            Insert.IntoTable("todos").Row(new { UserId = 3, Title = "Workout", Description = "30-minute cardio session", IsCompleted = true });
            Insert.IntoTable("todos").Row(new { UserId = 4, Title = "Call mom", Description = "Check in and have a chat", IsCompleted = false });
            Insert.IntoTable("todos").Row(new { UserId = 5, Title = "Clean the house", Description = "Sweep and mop all floors", IsCompleted = true });
            Insert.IntoTable("todos").Row(new { UserId = 1, Title = "Read book", Description = "Finish reading 2 chapters", IsCompleted = false });
            Insert.IntoTable("todos").Row(new { UserId = 2, Title = "Pay bills", Description = "Electricity and internet", IsCompleted = true });
            Insert.IntoTable("todos").Row(new { UserId = 3, Title = "Attend meeting", Description = "Project kickoff meeting at 10 AM", IsCompleted = false });
            Insert.IntoTable("todos").Row(new { UserId = 4, Title = "Buy dog food", Description = "Dry dog food, 10kg bag", IsCompleted = true });
            Insert.IntoTable("todos").Row(new { UserId = 5, Title = "Plan vacation", Description = "Look for resorts in Batangas", IsCompleted = false });
        }

        public override void Down()
        {
            Delete.Table("todos");
        }
    }
}
