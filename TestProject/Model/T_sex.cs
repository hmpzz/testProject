﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration;

namespace Model
{
    public class T_sex
    {
        /// <summary>
        /// 性别类
        /// </summary>



            //public T_sex()
            //{
            //    T_users = new HashSet<T_user>();
            //}


            #region T_sex属性

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
            public int id { get; set; }










            /// <summary>            /// 性别编号            /// </summary>        [Required, Key]
            public int sex_no { get; set; }










            /// <summary>            /// 员工姓名            /// </summary>        [DefaultValue(""), Required] //默认值，必填项
            public string sex_name { get; set; }


            /// <summary>
            /// 对应的员工对象
            /// </summary>
            //public virtual ICollection<T_user> T_users { get; set; }

            #endregion
        }

        public class T_sexMap : EntityTypeConfiguration<T_sex>
        {
            public T_sexMap()
            {

                //HasMany(d => d.T_users)
                //.WithRequired(d => d.sex)
                //.HasForeignKey(p => p.sex_no);
            }
        }
    
}
