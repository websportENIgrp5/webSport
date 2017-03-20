using DAL.EntityFramework;
using System;


namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed;
        private WebSportEntities context;
        private DifficulteRepository _difficulteRepo;
        private GenericRepository<ContributorEntity> _contributorRepo;
        private RaceRepository _raceRepo;
        private PoiRepository _poiRepo;

        #region Constructors

        public UnitOfWork()
            : this(new WebSportEntities())
        {
        }

        public UnitOfWork(WebSportEntities context)
        {
            this.context = context;
        }

        #endregion

        #region Repositories

       
        public RaceRepository RaceRepo
        {
            get
            {
                if (_raceRepo == null)
                    _raceRepo = new RaceRepository(this.context);
                return _raceRepo;
            }
        }

        public GenericRepository<ContributorEntity> ContributorRepo
        {
            get
            {
                if (_contributorRepo == null)
                    _contributorRepo = new GenericRepository<ContributorEntity>(this.context);
                return _contributorRepo;
            }
        }

        public DifficulteRepository DifficulteRepo
        {
            get
            {
                if (_difficulteRepo == null)
                    _difficulteRepo = new DifficulteRepository(this.context);
                return _difficulteRepo;
            }
        }

        public PoiRepository poiRepo
        {
            get
            {
                if (_poiRepo == null)
                    _poiRepo = new PoiRepository(this.context);
                return _poiRepo;
            }
        }

        private CategoryRaceRepository _categoryRaceRepo;
        public CategoryRaceRepository CategoryRaceRepo
        {
            get
            {
                if (_categoryRaceRepo == null)
                    _categoryRaceRepo = new CategoryRaceRepository(this.context);
                return _categoryRaceRepo;
            }
        }

        // Etc... on liste les repositories

        #endregion

        #region Public methods

        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Dispose the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the instance if it's not already
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        #endregion
    }
}
