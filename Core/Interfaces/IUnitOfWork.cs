using Core.Entities;

namespace Core.Interfaces;
public interface IUnitOfWork
{
    IArea Areas {get;}        
    IAreaUser AreaUsers {get;}        
    ICategoryContact CategoryContacts {get;}        
    IContact Contacts {get;}        
    IContactType ContactTypes {get;}        
    IDetailIncidence DetailIncidences {get;}        
    IDocumentType DocumentTypes {get;}        
    IIncidence Incidences {get;}        
    ILevelIncidence LevelIncidences {get;}        
    IPeripheral Peripherals {get;}        
    IPlace Places {get;}        
    IRol Rols {get;}        
    IState States {get;}        
    ITypeIncidence TypeIncidences {get;}        
    IUser Users {get;}        
    
    
    Task<int> SaveAsync();
}