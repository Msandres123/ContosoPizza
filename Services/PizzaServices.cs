using ContosoPizza.Models;

namespace ContosoPizza.Services;
public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false, Description = "Pizza ipsum dolor amet in esse pineapple voluptate laborum ipsum velit chicken wing, cupidatat thin crust beef ut nisi bbq sauce. Magna garlic et ipsum aliquip. Thin crust nulla garlic sauce, philly steak ut bbq et mushrooms white garlic mayo pineapple aute ex. Fugiat sed sunt pie. Pie pepperoni est mozzarella hawaiian." },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true, Description = "Pizza ipsum dolor amet ranch peppers garlic sauce white garlic pineapple steak. Beef pork hand tossed pineapple stuffed crust hawaiian sausage ricotta thin crust. Mushrooms chicken wing burnt mouth chicken wing ranch string cheese. Black olives chicken extra sauce sauteed onions spinach. Philly steak white garlic sausage mozzarella pepperoni meatball pizza roll black olives pork banana peppers melted cheese." }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}