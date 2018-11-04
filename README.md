# fit-frig
Frig storage and fitness tracker

## Database migrations
cd src/FitFrig.Web

### Add new migration
dotnet ef migrations add {Migration name}

### Update database
dotnet ef database update --context FoodDbContext