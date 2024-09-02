using CSharpFunctionalExtensions;

namespace coIT.Toolkit.AbsencesExport.Infrastructure.Infrastructure.Mapping
{
    public interface IExportRelationsRepository
    {
        public Task<Result<List<ExportRelations>>> GetAll(
            CancellationToken cancellationToken = default
        );

        public Task<Result> Save(
            ExportRelations exportRelation,
            CancellationToken cancellationToken = default
        );
    }
}
