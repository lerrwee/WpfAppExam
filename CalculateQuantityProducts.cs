using System;

namespace WpfAppExam
{
    internal class CalculateQuantityProducts
    {
        ExemsDBEntities entities = new ExemsDBEntities();
        public int QuantityProducts(int productsId, int materialsId, int quantityMaterials, int length, int width)
        {
            if (productsId <= 0 || materialsId <= 0 || quantityMaterials <= 0 || length <= 0 || width <= 0)
                return -1;

            ProductType productType = entities.ProductType.Find(productsId);
            MaterialType materialType = entities.MaterialType.Find(materialsId);

            if (productType == null || materialType == null)
                return -1;

            try
            {
                decimal КоличествоСырья = (length * width) * productType.ProductTypeCoefficient;

                decimal ПроцентПотериСырья = quantityMaterials * materialType.DefectPercentage;

                int КоличестоПродукции = (int)Math.Floor(КоличествоСырья / ПроцентПотериСырья);

                return КоличестоПродукции;
            }
            catch
            {
                return -1;
            }
        }
    }
}
