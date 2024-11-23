using Domain.Authentication;

namespace Domain;

public class BaseEntity
{
    /// <summary>
    /// Identification
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// The date it was created
    /// </summary>
    public DateTime Created { get; set; }
    /// <summary>
    /// From which user was created
    /// </summary>
    public long? CreatedById { get; set; }
    /// <summary>
    /// The date it was last updated
    /// </summary>
    public DateTime LastUpdated { get; set; }
    /// <summary>
    /// From which user was last updated
    /// </summary>
    public long? LastUpdatedById { get; set; }

    #region References
    public User? CreatedBy { get; set; }
    public User? LastUpdatedBy { get; set; }
    #endregion References


    /// <summary>
    /// Set the Created by properties
    /// </summary>
    /// <param name="userId"></param>
    public void SetCreatedBy(long userId) {
        CreatedById = userId;
        Created = DateTime.UtcNow;
        LastUpdatedById = userId;
        LastUpdated = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Set the last Updated by properties
    /// </summary>
    /// <param name="userId"></param>
    public void SetLastUpdatedBy(long userId) {
        LastUpdatedById = userId;
        LastUpdated = DateTime.UtcNow;
    }
}
