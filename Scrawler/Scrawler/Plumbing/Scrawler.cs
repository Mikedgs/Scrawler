using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;
using Mindscape.LightSpeed.Validation;

namespace Scrawler.Plumbing
{
    [Serializable]
    [GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    [DataObject]
    [Table(IdentityMethod = IdentityMethod.IdentityColumn)]
    public class Chatroom : Entity<int>
    {
        #region Fields

        private string _chatroom_name;
        [Column("created_at")] private DateTime _createdAt;
        [Column("firebase_id")] private string _firebaseId;
        [Column("hidden_url")] [ValidatePresence] [ValidateLength(0, 10)] private string _hiddenUrl;

        #endregion

        #region Field attribute and view names

        /// <summary>Identifies the HiddenUrl entity attribute.</summary>
        public const string HiddenUrlField = "HiddenUrl";

        /// <summary>Identifies the FirebaseId entity attribute.</summary>
        public const string FirebaseIdField = "FirebaseId";

        /// <summary>Identifies the CreatedAt entity attribute.</summary>
        public const string CreatedAtField = "CreatedAt";

        /// <summary>Identifies the chatroom_name entity attribute.</summary>
        public const string chatroom_nameField = "chatroom_name";

        #endregion

        #region Relationships

        [ReverseAssociation("Chatroom")] private readonly EntityCollection<Message> _messages =
            new EntityCollection<Message>();

        #endregion

        #region Properties

        [DebuggerNonUserCode]
        public EntityCollection<Message> Messages
        {
            get { return Get(_messages); }
        }


        [DebuggerNonUserCode]
        public string HiddenUrl
        {
            get { return Get(ref _hiddenUrl, "HiddenUrl"); }
            set { Set(ref _hiddenUrl, value, "HiddenUrl"); }
        }

        [DebuggerNonUserCode]
        public string FirebaseId
        {
            get { return Get(ref _firebaseId, "FirebaseId"); }
            set { Set(ref _firebaseId, value, "FirebaseId"); }
        }

        [DebuggerNonUserCode]
        public DateTime CreatedAt
        {
            get { return Get(ref _createdAt, "CreatedAt"); }
            set { Set(ref _createdAt, value, "CreatedAt"); }
        }

        [DebuggerNonUserCode]
        public string chatroom_name
        {
            get { return Get(ref _chatroom_name, "chatroom_name"); }
            set { Set(ref _chatroom_name, value, "chatroom_name"); }
        }

        #endregion
    }


    [Serializable]
    [GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    [DataObject]
    public class Admin : Entity<int>
    {
        #region Fields

        [ValidatePresence] [ValidateLength(0, 100)] private string _password;
        [Column("user_name")] [ValidatePresence] [ValidateLength(0, 30)] private string _userName;

        #endregion

        #region Field attribute and view names

        /// <summary>Identifies the UserName entity attribute.</summary>
        public const string UserNameField = "UserName";

        /// <summary>Identifies the Password entity attribute.</summary>
        public const string PasswordField = "Password";

        #endregion

        #region Properties

        [DebuggerNonUserCode]
        public string UserName
        {
            get { return Get(ref _userName, "UserName"); }
            set { Set(ref _userName, value, "UserName"); }
        }

        [DebuggerNonUserCode]
        public string Password
        {
            get { return Get(ref _password, "Password"); }
            set { Set(ref _password, value, "Password"); }
        }

        #endregion
    }


    [Serializable]
    [GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    [DataObject]
    public class Message : Entity<int>
    {
        #region Fields

        [ValidatePresence] [ValidateLength(0, 140)] private string _body;
        [Column("chatroom_id")] private int _chatroomId;
        [Column("created_at")] private DateTime _createdAt;
        [Column("message_id")] [ValidateLength(0, 50)] private string _messageId;
        [ValidateLength(0, 50)] private string _username;
        private int? _votes;

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

        /// <summary>Identifies the MessageId entity attribute.</summary>
        public const string MessageIdField = "MessageId";

        /// <summary>Identifies the ChatroomId entity attribute.</summary>
        public const string ChatroomIdField = "ChatroomId";

        #endregion

        #region Relationships

        [ReverseAssociation("Messages")] private readonly EntityHolder<Chatroom> _chatroom =
            new EntityHolder<Chatroom>();

        #endregion

        #region Properties

        [DebuggerNonUserCode]
        public Chatroom Chatroom
        {
            get { return Get(_chatroom); }
            set { Set(_chatroom, value); }
        }


        [DebuggerNonUserCode]
        public DateTime CreatedAt
        {
            get { return Get(ref _createdAt, "CreatedAt"); }
            set { Set(ref _createdAt, value, "CreatedAt"); }
        }

        [DebuggerNonUserCode]
        public string Body
        {
            get { return Get(ref _body, "Body"); }
            set { Set(ref _body, value, "Body"); }
        }

        [DebuggerNonUserCode]
        public string Username
        {
            get { return Get(ref _username, "Username"); }
            set { Set(ref _username, value, "Username"); }
        }

        [DebuggerNonUserCode]
        public int? Votes
        {
            get { return Get(ref _votes, "Votes"); }
            set { Set(ref _votes, value, "Votes"); }
        }

        [DebuggerNonUserCode]
        public string MessageId
        {
            get { return Get(ref _messageId, "MessageId"); }
            set { Set(ref _messageId, value, "MessageId"); }
        }

        /// <summary>Gets or sets the ID for the <see cref="Chatroom" /> property.</summary>
        [DebuggerNonUserCode]
        public int ChatroomId
        {
            get { return Get(ref _chatroomId, "ChatroomId"); }
            set { Set(ref _chatroomId, value, "ChatroomId"); }
        }

        #endregion
    }


    /// <summary>
    ///     Provides a strong-typed unit of work for working with the Scrawler model.
    /// </summary>
    [GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
    public class ScrawlerUnitOfWork : UnitOfWork
    {
        public IQueryable<Chatroom> Chatrooms
        {
            get { return this.Query<Chatroom>(); }
        }

        public IQueryable<Admin> Admins
        {
            get { return this.Query<Admin>(); }
        }

        public IQueryable<Message> Messages
        {
            get { return this.Query<Message>(); }
        }
    }
}