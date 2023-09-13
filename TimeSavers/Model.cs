using System;

namespace TimeSavers
{
    public class Model
    {

    }

    public class Rootobject
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public string profilePhoto { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public bool isEnabled { get; set; }
        public Security security { get; set; }
    }

    public class Security
    {
        public string email { get; set; }
        public string password { get; set; }
        public string securityQuestion { get; set; }
        public string answer { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class user
    {

        private string emailField;

        private string firstNameField;

        private string lastNameField;

        private string contactNumberField;

        private string addressField;

        private string cityField;

        private string countryField;

        private string zipCodeField;

        private string profilePhotoField;

        private string createdByField;

        private System.DateTime createdDateField;

        private string updatedByField;

        private System.DateTime updatedDateField;

        private bool isEnabledField;

        private userSecurity securityField;

        /// <remarks/>
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public string contactNumber
        {
            get
            {
                return this.contactNumberField;
            }
            set
            {
                this.contactNumberField = value;
            }
        }

        /// <remarks/>
        public string address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string zipCode
        {
            get
            {
                return this.zipCodeField;
            }
            set
            {
                this.zipCodeField = value;
            }
        }

        /// <remarks/>
        public string profilePhoto
        {
            get
            {
                return this.profilePhotoField;
            }
            set
            {
                this.profilePhotoField = value;
            }
        }

        /// <remarks/>
        public string createdBy
        {
            get
            {
                return this.createdByField;
            }
            set
            {
                this.createdByField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createdDate
        {
            get
            {
                return this.createdDateField;
            }
            set
            {
                this.createdDateField = value;
            }
        }

        /// <remarks/>
        public string updatedBy
        {
            get
            {
                return this.updatedByField;
            }
            set
            {
                this.updatedByField = value;
            }
        }

        /// <remarks/>
        public System.DateTime updatedDate
        {
            get
            {
                return this.updatedDateField;
            }
            set
            {
                this.updatedDateField = value;
            }
        }

        /// <remarks/>
        public bool isEnabled
        {
            get
            {
                return this.isEnabledField;
            }
            set
            {
                this.isEnabledField = value;
            }
        }

        /// <remarks/>
        public userSecurity security
        {
            get
            {
                return this.securityField;
            }
            set
            {
                this.securityField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class userSecurity
    {

        private string emailField;

        private string passwordField;

        private string securityQuestionField;

        private string answerField;

        private string createdByField;

        private System.DateTime createdDateField;

        private string updatedByField;

        private System.DateTime updatedDateField;

        /// <remarks/>
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string securityQuestion
        {
            get
            {
                return this.securityQuestionField;
            }
            set
            {
                this.securityQuestionField = value;
            }
        }

        /// <remarks/>
        public string answer
        {
            get
            {
                return this.answerField;
            }
            set
            {
                this.answerField = value;
            }
        }

        /// <remarks/>
        public string createdBy
        {
            get
            {
                return this.createdByField;
            }
            set
            {
                this.createdByField = value;
            }
        }

        /// <remarks/>
        public System.DateTime createdDate
        {
            get
            {
                return this.createdDateField;
            }
            set
            {
                this.createdDateField = value;
            }
        }

        /// <remarks/>
        public string updatedBy
        {
            get
            {
                return this.updatedByField;
            }
            set
            {
                this.updatedByField = value;
            }
        }

        /// <remarks/>
        public System.DateTime updatedDate
        {
            get
            {
                return this.updatedDateField;
            }
            set
            {
                this.updatedDateField = value;
            }
        }
    }




}
