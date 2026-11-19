using System;

namespace Decorator.Examples
{
    // Component
    interface IChristmasTree
    {
        void Show();
        void Shine();
    }

    // ConcreteComponent
    class ChristmasTree : IChristmasTree
    {
        public void Show()
        {
            Console.WriteLine("Ялинка");
        }

        public void Shine()
        {
            Console.WriteLine("Ялинка не світиться.");
        }
    }

    // Decorator
    abstract class TreeDecorator : IChristmasTree
    {
        protected readonly IChristmasTree tree;

        protected TreeDecorator(IChristmasTree tree)
        {
            this.tree = tree;
        }

        public virtual void Show()
        {
            tree.Show();
        }

        public virtual void Shine()
        {
            tree.Shine();
        }
    }

    // ConcreteDecorator: Christmas ornaments
    class OrnamentDecorator : TreeDecorator
    {
        private readonly string ornamentType;
        private readonly int ornamentCount;

        public OrnamentDecorator(
            IChristmasTree tree,
            string ornamentType,
            int ornamentCount)
            : base(tree)
        {
            this.ornamentType = ornamentType;
            this.ornamentCount = ornamentCount;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine(
                $"Прикраси: {ornamentType}, кількість: {ornamentCount}");
        }
    }

    // ConcreteDecorator: Garland
    class GarlandDecorator : TreeDecorator
    {
        private readonly string garlandColor;

        public GarlandDecorator(IChristmasTree tree, string garlandColor)
            : base(tree)
        {
            this.garlandColor = garlandColor;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Гірлянда: {garlandColor}");
        }

        public override void Shine()
        {
            Console.WriteLine(
                $"Ялинка світиться! Колір гірлянди: {garlandColor}.");
        }
    }

    class MainApp
    {
        static void Main()
        {
            Console.WriteLine("1. Звичайна ялинка:");
            IChristmasTree simpleTree = new ChristmasTree();
            simpleTree.Show();
            simpleTree.Shine();

            Console.WriteLine("\n2. Ялинка тільки з прикрасами:");
            IChristmasTree treeWithOrnaments = new OrnamentDecorator(
                new ChristmasTree(),
                "червоні кульки",
                12);
            treeWithOrnaments.Show();
            treeWithOrnaments.Shine();

            Console.WriteLine("\n3. Ялинка тільки з гірляндою:");
            IChristmasTree treeWithGarland = new GarlandDecorator(
                new ChristmasTree(),
                "золота");
            treeWithGarland.Show();
            treeWithGarland.Shine();

            Console.WriteLine("\n4. Ялинка з прикрасами та гірляндою:");
            IChristmasTree decoratedTree = new ChristmasTree();
            decoratedTree = new OrnamentDecorator(
                decoratedTree,
                "срібні кульки",
                20);
            decoratedTree = new GarlandDecorator(
                decoratedTree,
                "різнокольорова");

            decoratedTree.Show();
            decoratedTree.Shine();
        }
    }
}
