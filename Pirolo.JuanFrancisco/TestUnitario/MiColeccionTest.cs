namespace TestUnitario
{
    [TestClass]
    public class MiColeccionTest
    {
        [TestMethod]
        public void AgregarElemento_NoExisteEnLaColeccion_ElementoAgregado()
        {
            /// <summary>
            /// Verifica que al agregar un elemento a la colecci�n, el elemento se a�ade correctamente si no existe previamente.
            /// </summary>
            var coleccion = new FutbolArgentino.MiColeccion<string>();
            string elemento = "Ejemplo";

            // Act
            coleccion += elemento;

            // Assert
            Assert.IsTrue(coleccion.Contiene(elemento));
        }


        /// <summary>
        /// Asegura que un elemento no se agrega m�s de una vez a la colecci�n.
        /// </summary>
        [TestMethod]
        public void AgregarElemento_YaExisteEnLaColeccion_ElementoNoAgregado()
        {
            // Arrange
            var coleccion = new FutbolArgentino.MiColeccion<string>();
            string elemento = "Ejemplo";

            // Act
            coleccion += elemento; // Primera vez
            coleccion += elemento; // Segunda vez

            // Assert
            Assert.AreEqual(1, coleccion.elementos.Count); // Asegura que el elemento no se haya agregado dos veces
        }


        /// <summary>
        /// Asegura que al eliminar un elemento de la colecci�n, este se elimina correctamente.
        /// </summary>
        [TestMethod]
        public void EliminarElemento_ElementoExiste_ElementoEliminado()
        {
            // Arrange
            var coleccion = new FutbolArgentino.MiColeccion<string>();
            string elemento = "Ejemplo";
            coleccion += elemento; // Agrega el elemento para asegurarse de que exista

            // Act
            coleccion -= elemento;

            // Assert
            Assert.IsFalse(coleccion.Contiene(elemento));
        }


        /// <summary>
        /// Verifica que la colecci�n devuelve 'true' si contiene un elemento espec�fico.
        /// </summary>
        [TestMethod]
        public void ContieneElemento_ElementoExiste_ValorTrue()
        {
            // Arrange
            var coleccion = new FutbolArgentino.MiColeccion<string>();
            string elemento = "Ejemplo";
            coleccion += elemento; // Agrega el elemento para asegurarse de que exista

            // Act
            bool contieneElemento = coleccion.Contiene(elemento);

            // Assert
            Assert.IsTrue(contieneElemento);
        }


        /// <summary>
        /// Verifica que la colecci�n devuelve 'false' si no contiene un elemento espec�fico.
        /// </summary>
        [TestMethod]
        public void ContieneElemento_ElementoNoExiste_ValorFalse()
        {
            // Arrange
            var coleccion = new FutbolArgentino.MiColeccion<string>();
            string elemento = "Ejemplo";

            // Act
            bool contieneElemento = coleccion.Contiene(elemento);

            // Assert
            Assert.IsFalse(contieneElemento);
        }
    }
}