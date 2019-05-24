using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class DbProviderMockTests
    {
        [TestMethod]
        public void Destructor_Invoking_Demo()
        {
            ConstructAndFreeUpReference();
            //ConstructAndFreeUpReferenceWithUsing();
            ConstructAndFreeUpReferenceButDevIsPlaingWithGC();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            1000.Sleep(true);
        }

        private static void ConstructAndFreeUpReference()
        {
            new DbProviderMock("Green, green ... I pink up the phone and I say 'yellow'.");
        }

        private static void ConstructAndFreeUpReferenceWithUsing()
        {
            using (var db = new DbProviderMock())
            {
                db.ToString(); // and any other method invoking for implement any bussines logic
            } // Implicite invoking Dispose() in the place 'currly bracket'. Possible only with IDisposable implementation
        }

        private static void ConstructAndFreeUpReferenceButDevIsPlaingWithGC()
        {
            var db = new DbProviderMock();
            db.Dispose();
            GC.ReRegisterForFinalize(db);
        }
    }
}
