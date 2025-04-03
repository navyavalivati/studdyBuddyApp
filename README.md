## Study Buddy App

Study Buddy App is a web application built with ASP.NET Core that helps students create and manage study groups, schedule sessions, share resources, and collaborate with peers. It offers both individual and group study management features, with authentication via ASP.NET Identity and a user-friendly dashboard.

# Technologies Used

- ASP.NET Core (MVC & Razor Pages)
- Entity Framework Core (for database management)
- PostgreSQL (relational database)
- Bootstrap 5 (UI framework)
- jQuery (for frontend interactivity)

# Installation
1. Clone the Repository
```bash
   git clone https://github.com/your-username/StudyBuddyApp.git
   cd StudyBuddyApp
```
2. Set Up Database
```json
  {
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=studybuddydb;Username=yourusername;Password=yourpassword"
  }
}
```
3. Run Migrations
```bash
    dotnet ef database update
```
4. Run the Application
```bash
  dotnet run
```
Then navigate to http://localhost:5000 in your browser.

# Usage
**Register and Log In**
1. Navigate to Login/Register to create an account or sign in.
2. After logging in, you can create study groups, join existing ones, and begin collaborating with other users.

**Create a Study Group**
1. Go to the Dashboard and click Create Group.
2. Provide the group name, description, and subject.
3. An Invite Code will be automatically generated for sharing with others.

**Join a Study Group**
1. Use the Invite Code to join existing study groups.
2. Once you join, you can access the group, see resources, and schedule study sessions.

**Manage Sessions and Resources**
1. Schedule Study Sessions: Set up sessions with time, location, and topic.
2. Share Resources: Upload and share study materials with group members.




























