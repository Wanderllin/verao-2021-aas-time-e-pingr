public void Register(RegisterInputModel input)
{
  // Push a command through the stack
  using (var db = new CommandDbContext())
  {
    var c = new Customer {
      FirstName = input.FirstName,
      LastName = input.LastName };
    db.Customers.Add(c);
    db.SaveChanges();
  }
}
