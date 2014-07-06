using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace Scrawler.Plumbing
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class Chatroom : Entity<int>
  {
    #region Fields
  
    [Column("hidden_url")]
    [ValidatePresence]
    [ValidateLength(0, 10)]
    private string _hiddenUrl;
    [Column("firebase_id")]
    private string _firebaseId;
    [Column("created_at")]
    private System.DateTime _createdAt;
    private string _chatroomName;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the HiddenUrl entity attribute.</summary>
    public const string HiddenUrlField = "HiddenUrl";
    /// <summary>Identifies the FirebaseId entity attribute.</summary>
    public const string FirebaseIdField = "FirebaseId";
    /// <summary>Identifies the CreatedAt entity attribute.</summary>
    public const string CreatedAtField = "CreatedAt";
    /// <summary>Identifies the ChatroomName entity attribute.</summary>
    public const string ChatroomNameField = "ChatroomName";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Chatroom")]
    private readonly EntityCollection<Message> _messages = new EntityCollection<Message>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Message> Messages
    {
      get { return Get(_messages); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string HiddenUrl
    {
      get { return Get(ref _hiddenUrl, "HiddenUrl"); }
      set { Set(ref _hiddenUrl, value, "HiddenUrl"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string FirebaseId
    {
      get { return Get(ref _firebaseId, "FirebaseId"); }
      set { Set(ref _firebaseId, value, "FirebaseId"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime CreatedAt
    {
      get { return Get(ref _createdAt, "CreatedAt"); }
      set { Set(ref _createdAt, value, "CreatedAt"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string ChatroomName
    {
      get { return Get(ref _chatroomName, "ChatroomName"); }
      set { Set(ref _chatroomName, value, "ChatroomName"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class Message : Entity<int>
  {
    #region Fields
  
    [Column("created_at")]
    private System.DateTime _createdAt;
    [ValidatePresence]
    [ValidateLength(0, 140)]
    private string _body;
    [ValidateLength(0, 50)]
    private string _username;
    private System.Nullable<int> _votes;
    [Column("chatroom_id")]
    private int _chatroomId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the CreatedAt entity attribute.</summary>
    public const string CreatedAtField = "CreatedAt";
    /// <summary>Identifies the Body entity attribute.</summary>
    public const string BodyField = "Body";
    /// <summary>Identifies the Username entity attribute.</summary>
    public const string UsernameField = "Username";
    /// <summary>Identifies the Votes entity attribute.</summary>
    public const string VotesField = "Votes";
    /// <summary>Identifies the ChatroomId entity attribute.</summary>
    public const string ChatroomIdField = "ChatroomId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Messages")]
    private readonly EntityHolder<Chatroom> _chatroom = new EntityHolder<Chatroom>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Chatroom Chatroom
    {
      get { return Get(_chatroom); }
      set { Set(_chatroom, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public System.DateTime CreatedAt
    {
      get { return Get(ref _createdAt, "CreatedAt"); }
      set { Set(ref _createdAt, value, "CreatedAt"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Body
    {
      get { return Get(ref _body, "Body"); }
      set { Set(ref _body, value, "Body"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Username
    {
      get { return Get(ref _username, "Username"); }
      set { Set(ref _username, value, "Username"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<int> Votes
    {
      get { return Get(ref _votes, "Votes"); }
      set { Set(ref _votes, value, "Votes"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="Chatroom" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public int ChatroomId
    {
      get { return Get(ref _chatroomId, "ChatroomId"); }
      set { Set(ref _chatroomId, value, "ChatroomId"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the Scrawler model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class ScrawlerUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<Chatroom> Chatrooms
    {
      get { return this.Query<Chatroom>(); }
    }
    
    public System.Linq.IQueryable<Message> Messages
    {
      get { return this.Query<Message>(); }
    }
    
  }

}
