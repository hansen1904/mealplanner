using ExcelDataReader;
using mealplanner.Application.Repository;
using mealplanner.Domain.Entities;
using MediatR;

namespace mealplanner.Application.FoodItems.Commands.ReadExcelFile
{
    public sealed record ReadExcelFileCommand : IRequest
    {
    }

    public sealed class ReadExcelFileCommandEventHandler : IRequestHandler<ReadExcelFileCommand>
    {
        private IUnitOfWork _unitOfWork;

        public ReadExcelFileCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(ReadExcelFileCommand request, CancellationToken cancellationToken)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var filePath = "C:/Users/hanse/OneDrive/Desktop/Frida_5.1_November_2023.xlsx";

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {


                    var dataset = reader.AsDataSet();
                    var table = dataset.Tables[1];

                    for (int i = 4; i < table.Rows.Count; i++)
                    {
                        var FoodName = table.Rows[i][0].ToString();
                        var Calories = 0.0;
                        var Protein = 0.0;
                        var Carbohydrate = 0.0;
                        var Fiber = 0.0;
                        var Fat = 0.0;
                        var Sugar = 0.0;
                        var Salt = 0.0;


                        try
                        {
                            Calories = String.IsNullOrWhiteSpace(table.Rows[i][5].ToString()) ? 0.0 : Double.Parse(table.Rows[i][5].ToString());
                            Protein = String.IsNullOrWhiteSpace(table.Rows[i][7].ToString()) ? 0.0 : Double.Parse(table.Rows[i][7].ToString());
                            Carbohydrate = String.IsNullOrWhiteSpace(table.Rows[i][10].ToString()) ? 0.0 : Double.Parse(table.Rows[i][10].ToString());
                            Fiber = String.IsNullOrWhiteSpace(table.Rows[i][13].ToString()) ? 0.0 : Double.Parse(table.Rows[i][13].ToString());
                            Fat = String.IsNullOrWhiteSpace(table.Rows[i][14].ToString()) ? 0.0 : Double.Parse(table.Rows[i][14].ToString());
                            Sugar = String.IsNullOrWhiteSpace(table.Rows[i][16].ToString()) ? 0.0 : Double.Parse(table.Rows[i][16].ToString());
                            Salt = String.IsNullOrWhiteSpace(table.Rows[i][87].ToString()) ? 0.0 : Double.Parse(table.Rows[i][87].ToString());

                            var NewFooditem = FoodItem.Create(
                            FoodName.ToLowerInvariant(),
                            "NoBrand".ToLowerInvariant(),
                            Domain.Enums.FoodCategory.None,
                            Calories,
                            Protein,
                            Carbohydrate,
                            Fat,
                            Fiber,
                            Sugar,
                            Salt);

                            _unitOfWork.FoodItemRepo().Create(NewFooditem);
                            _unitOfWork.Save();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }                    
                }
            }


            return Task.CompletedTask;
        }
    }
}
