using CylinderProject.Models;

namespace CylinderTestCode
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var Cylinder = new Cylinder(5.5, 7.5);
            Assert.Equal(5.5, Cylinder.Radius);
            Assert.Equal(7.5, Cylinder.Height);
        }

        [Theory]
        [InlineData(-5.5, -7.5)]

        public void IsNegativeOrNull(double radius, double height)
        {
            Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
        }

        [Fact]
        public void VolumeAndSurfaceArea()
        {
            var Cylinder = new Cylinder(5.5, 7.5);

            var volume = Cylinder.GetVolume();
            var surfaceArea = Cylinder.GetSurfaceArea();

            Assert.Equal(Math.PI * Math.Pow(5.5, 2) * 7.5, volume);
            Assert.Equal(2 * Math.PI * Math.Pow(5.5, 2) + 2 * Math.PI * 5.5 * 7.5, surfaceArea);
        }


        [Theory]
        [InlineData(7.5, 9.5)]
        [InlineData(-7.5, -9.5)]

        public void Frissit(double newRadius, double newHeight)
        {
            var Cylinder = new Cylinder(5.5, 7.5);

            Assert.Throws<ArgumentException>(() => Cylinder.Resize(newRadius, newHeight));


        }

        [Fact]
        public void FrissitMegegyezik()
        {
            var Cylinder = new Cylinder(5.5, 7.5);
            var newRadius = 7.5;
            var newHeight = 9.5;
            Cylinder.Resize(newRadius, newHeight);
            Assert.Equal(newRadius, Cylinder.Radius);
            Assert.Equal(newHeight, Cylinder.Height);

        }

        [Fact]
        public void CylinderNotNull()
        {
            var Cylinder = new Cylinder(5.5, 7.5);

            Assert.NotNull(Cylinder);
        }


        [Fact]
        public void RadiusInRange()
        {
            var Cylinder = new Cylinder(5.5, 7.5);

            Assert.InRange(Cylinder.Radius, 1, 100);
        }
    }
}