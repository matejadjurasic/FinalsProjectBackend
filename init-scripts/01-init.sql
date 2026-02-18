-- FitnessPal Database Initialization Script

CREATE TABLE IF NOT EXISTS "AspNetRoles" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(256),
    "NormalizedName" VARCHAR(256),
    "ConcurrencyStamp" TEXT
);

CREATE TABLE IF NOT EXISTS "AspNetUsers" (
    "Id" SERIAL PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Height" DOUBLE PRECISION NOT NULL,
    "Weight" DOUBLE PRECISION NOT NULL,
    "Age" INTEGER NOT NULL,
    "Gender" INTEGER NOT NULL,
    "UserName" VARCHAR(256),
    "NormalizedUserName" VARCHAR(256),
    "Email" VARCHAR(256),
    "NormalizedEmail" VARCHAR(256),
    "EmailConfirmed" BOOLEAN NOT NULL,
    "PasswordHash" TEXT,
    "SecurityStamp" TEXT,
    "ConcurrencyStamp" TEXT,
    "PhoneNumber" TEXT,
    "PhoneNumberConfirmed" BOOLEAN NOT NULL,
    "TwoFactorEnabled" BOOLEAN NOT NULL,
    "LockoutEnd" TIMESTAMPTZ,
    "LockoutEnabled" BOOLEAN NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS "Ingredients" (
    "Id" SERIAL PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "Calories" INTEGER NOT NULL,
    "Protein" DOUBLE PRECISION NOT NULL,
    "Carbs" DOUBLE PRECISION NOT NULL,
    "Fat" DOUBLE PRECISION NOT NULL,
    "DateCreated" TIMESTAMPTZ NOT NULL,
    "CreatedBy" TEXT NOT NULL,
    "LastModifiedDate" TIMESTAMPTZ NOT NULL,
    "LastModifiedBy" TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS "AspNetRoleClaims" (
    "Id" SERIAL PRIMARY KEY,
    "RoleId" INTEGER NOT NULL,
    "ClaimType" TEXT,
    "ClaimValue" TEXT,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "AspNetUserClaims" (
    "Id" SERIAL PRIMARY KEY,
    "UserId" INTEGER NOT NULL,
    "ClaimType" TEXT,
    "ClaimValue" TEXT,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT,
    "UserId" INTEGER NOT NULL,
    PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "AspNetUserRoles" (
    "UserId" INTEGER NOT NULL,
    "RoleId" INTEGER NOT NULL,
    PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "AspNetUserTokens" (
    "UserId" INTEGER NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT,
    PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "DailyWeights" (
    "Id" SERIAL PRIMARY KEY,
    "DateTime" TIMESTAMPTZ NOT NULL,
    "Weight" DOUBLE PRECISION NOT NULL,
    "UserId" INTEGER NOT NULL,
    "DateCreated" TIMESTAMPTZ NOT NULL,
    "CreatedBy" TEXT NOT NULL,
    "LastModifiedDate" TIMESTAMPTZ NOT NULL,
    "LastModifiedBy" TEXT NOT NULL,
    CONSTRAINT "FK_DailyWeights_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "Goals" (
    "Id" SERIAL PRIMARY KEY,
    "TargetCalories" INTEGER NOT NULL,
    "TargetProtein" DOUBLE PRECISION NOT NULL,
    "TargetCarbs" DOUBLE PRECISION NOT NULL,
    "TargetFats" DOUBLE PRECISION NOT NULL,
    "TargetWeight" DOUBLE PRECISION NOT NULL,
    "Type" INTEGER NOT NULL,
    "ActivityLevel" INTEGER NOT NULL,
    "UserId" INTEGER NOT NULL,
    "DateCreated" TIMESTAMPTZ NOT NULL,
    "CreatedBy" TEXT NOT NULL,
    "LastModifiedDate" TIMESTAMPTZ NOT NULL,
    "LastModifiedBy" TEXT NOT NULL,
    CONSTRAINT "FK_Goals_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "Meals" (
    "Id" SERIAL PRIMARY KEY,
    "Calories" INTEGER NOT NULL,
    "Protein" DOUBLE PRECISION NOT NULL,
    "Carbs" DOUBLE PRECISION NOT NULL,
    "Fat" DOUBLE PRECISION NOT NULL,
    "MealType" INTEGER NOT NULL,
    "DateTime" TIMESTAMPTZ NOT NULL,
    "UserId" INTEGER NOT NULL,
    "DateCreated" TIMESTAMPTZ NOT NULL,
    "CreatedBy" TEXT NOT NULL,
    "LastModifiedDate" TIMESTAMPTZ NOT NULL,
    "LastModifiedBy" TEXT NOT NULL,
    CONSTRAINT "FK_Meals_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "MealItems" (
    "MealId" INTEGER NOT NULL,
    "IngredientId" INTEGER NOT NULL,
    "Amount" DOUBLE PRECISION NOT NULL,
    PRIMARY KEY ("MealId", "IngredientId"),
    CONSTRAINT "FK_MealItems_Ingredients_IngredientId" FOREIGN KEY ("IngredientId") REFERENCES "Ingredients" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_MealItems_Meals_MealId" FOREIGN KEY ("MealId") REFERENCES "Meals" ("Id") ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");
CREATE UNIQUE INDEX IF NOT EXISTS "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");
CREATE INDEX IF NOT EXISTS "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");
CREATE INDEX IF NOT EXISTS "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");
CREATE INDEX IF NOT EXISTS "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");
CREATE INDEX IF NOT EXISTS "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");
CREATE UNIQUE INDEX IF NOT EXISTS "IX_AspNetUsers_Email" ON "AspNetUsers" ("Email");
CREATE UNIQUE INDEX IF NOT EXISTS "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");
CREATE INDEX IF NOT EXISTS "IX_DailyWeights_UserId" ON "DailyWeights" ("UserId");
CREATE INDEX IF NOT EXISTS "IX_Goals_UserId" ON "Goals" ("UserId");
CREATE INDEX IF NOT EXISTS "IX_MealItems_IngredientId" ON "MealItems" ("IngredientId");
CREATE INDEX IF NOT EXISTS "IX_Meals_UserId" ON "Meals" ("UserId");

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName") 
VALUES 
    (1, '00000000-0000-0000-0000-000000000000', 'Admin', 'ADMIN'),
    (2, '00000000-0000-0000-0000-000000000000', 'Client', 'CLIENT')
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "AspNetUsers" ("Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight")
VALUES 
    (1, 0, 0, 'e0635926-aec0-413f-94b6-c255cae26add', 'admin@email.com', false, 0, 0.0, false, null, 'Admin', 'ADMIN@EMAIL.COM', 'ADMIN', 'AQAAAAIAAYagAAAAEIavF+aQht8Qjw+5OG5o4s+qKJe+s0WwVusxXP6MHqdaRikidnpNGPFXi9K4oo8d/w==', null, false, null, false, 'admin', 0.0),
    (2, 0, 0, '709bff4d-8d73-48f9-b864-3dfc4c98eef3', 'client@email.com', false, 0, 0.0, false, null, 'Client', 'CLIENT@EMAIL.COM', 'CLIENT', 'AQAAAAIAAYagAAAAEHQwNztL0PZvpoDoRRjxM9/uAHxWYs2d29qZ2qWaYGbt5oJn/qb8W6PpA3a6fwpCZw==', null, false, null, false, 'client', 0.0)
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "Ingredients" ("Id", "Calories", "Carbs", "CreatedBy", "DateCreated", "Description", "Fat", "LastModifiedBy", "LastModifiedDate", "Name", "Protein")
VALUES (1, 216, 13.0, '', '0001-01-01 00:00:00+00', 'Description example', 3.0, '', '0001-01-01 00:00:00+00', 'Example', 10.0)
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO "AspNetUserRoles" ("RoleId", "UserId")
VALUES (1, 1), (2, 2)
ON CONFLICT DO NOTHING;

SELECT setval('"AspNetRoles_Id_seq"', (SELECT MAX("Id") FROM "AspNetRoles"));
SELECT setval('"AspNetUsers_Id_seq"', (SELECT MAX("Id") FROM "AspNetUsers"));
SELECT setval('"Ingredients_Id_seq"', (SELECT MAX("Id") FROM "Ingredients"));
