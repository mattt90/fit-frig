# fit-frig
Frig storage and fitness tracker

## Database migrations
cd src/Fit.Frig.Web

### Add new migration
dotnet ef migrations add {Migration name}

### Update database
dotnet ef database update --context FoodDbContext