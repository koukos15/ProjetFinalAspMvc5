


//protected override void Seed(CaffeGest.Models.ApplicationDbContext context)
//{
//    //  AddSomeProduits(context);
//    // AddSomeCategories(context);

//    AddRoles();
//}

//        public void AddRoles()
//        {
//            using (ApplicationDbContext ctx = new ApplicationDbContext())
//            {
//                if (!ctx.Roles.Any(r => r.Name == "User"))
//                {
//                    ctx.Roles.Add(new IdentityRole { Name = "User" });
//                    ctx.SaveChanges();
//                }

//                if (!ctx.Roles.Any(r => r.Name == "Admin"))
//                {
//                    ctx.Roles.Add(new IdentityRole { Name = "Admin" });
//                    ctx.SaveChanges();
//                }

//            }
//        }
//        private void AddSomeProduits(CaffeGest.Models.ApplicationDbContext context)
//        {
//            List<Produit> LesProduits = new List<Produit>
//            {
//                new Produit {Nom="LE Bon Cafe",PU = 25,Poids=50,QuantiteStock=400 },
//                new Produit {Nom="LE Bon Cafe",PU = 45,Poids=100,QuantiteStock=300 },
//                new Produit {Nom="Amina",PU = 20,Poids=50,QuantiteStock=270 },
//                new Produit {Nom="Amina",PU = 32,Poids=100,QuantiteStock=350 }
//            };
//            context.Produits.AddRange(LesProduits);
//        }
//        private void AddSomeCategories(CaffeGest.Models.ApplicationDbContext context)
//        {
//            List<Categorie> LesCategories = new List<Categorie>
//            {
//                new Categorie { Nom="Produits finis"},
//                new Categorie { Nom="Matiere 1ere"}
//            };
//            context.Categories.AddRange(LesCategories);
//        }


