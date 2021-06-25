namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Marks = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TblEmployee",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Class = c.Int(nullable: false),
                        Subjects = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.TblSubjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblSubjects");
            DropTable("dbo.TblEmployee");
            DropTable("dbo.TblCourse");
        }
    }
}
