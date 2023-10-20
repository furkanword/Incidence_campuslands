using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork,IDisposable
{    
    private readonly IncidenceContext _context;
    private AreaRepository? _area;
    private AreaUserRepository? _areaUser;
    private CategoryContactRepository? _categoryContact;
    private ContactRepository? _contact;
    private ContactTypeRepository? _contactType;
    private DetailIncidenceRepository? _detailIncidence;
    private DocumentTypeRepository? _documentType;
    private IncidenceRepository? _incidence;
    private LevelIncidenceRepository? _levelIncidence;
    private PeripheralRepository? _peripheral;
    private PlaceRepository? _place;
    private RolRepository? _rol;
    private StateRepository? _state;
    private TypeIncidenceRepository? _typeIncidence;
    private UserRepository? _user;

    public UnitOfWork(IncidenceContext context)=>_context = context;

    public IArea Areas{
        get{
            if(_area is not null){
                return _area;
            }
            return _area = new(_context);
        }
    }
    public IAreaUser AreaUsers{
        get{
            if(_areaUser is not null){
                return _areaUser;
            }
            return _areaUser = new(_context);
        }
    }
    public ICategoryContact CategoryContacts{
        get{
            if(_categoryContact is not null){
                return _categoryContact;
            }
            return _categoryContact = new(_context);
        }
    }
    public IContact Contacts{
        get{
            if(_contact is not null){
                return _contact;
            }
            return _contact = new (_context);
        }
    }
    public IContactType ContactTypes{
        get{
            if(_contactType is not null){
                return _contactType;
            }
            return  _contactType = new (_context);
        }
    }
    public IDetailIncidence DetailIncidences{
        get{
            if(_detailIncidence is not null){
                return _detailIncidence;
            }
            return _detailIncidence = new (_context);
        }
    }
    public IDocumentType DocumentTypes{
        get{
            if(_documentType is not null){
                return _documentType;
            }
            return _documentType = new (_context);
        }
    }
    public IIncidence Incidences{
        get{
            if(_incidence is not null){
                return _incidence;
            }
            return _incidence = new (_context);
        }
    }
    public ILevelIncidence LevelIncidences{
        get{
            if(_levelIncidence is not null){
                return _levelIncidence;
            }
            return _levelIncidence = new (_context);
        }
    }
    public IPeripheral Peripherals{
        get{
            if(_peripheral is not null){
                return _peripheral;
            }
            return _peripheral = new (_context);
        }
    }
    public IPlace Places{
        get{
            if(_place is not null){
                return _place;
            }
            return _place = new (_context);
        }
    }
    public IRol Rols{
        get{
            if(_rol is not null){
                return _rol;
            }
            return _rol = new (_context);
        }
    }
    public IState States{
        get{
            if(_state is not null){
                return _state;
            }
            return _state = new (_context);
        }
    }
    public ITypeIncidence TypeIncidences{
        get{
            if(_typeIncidence is not null){
                return _typeIncidence;
            }
            return _typeIncidence = new (_context);
        }
    }
    public IUser Users{
        get{
            if(_user is not null){
                return _user;
            }
            return _user = new (_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }
}