﻿//-----------------------------------------------------------------------
// <copyright file="IEmployeeBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommanLayer;
    
    /// <summary>
    /// interface for Employee Business Layer
    /// </summary>
    public interface IEmployeeBL
    {
        /// <summary>
        /// Method for returning All Employee Details
        /// </summary>
        /// <returns>return all employee details</returns>
        IEnumerable<Employees> GetAllEmployees();

        /// <summary>
        /// Method for returning specific Employee Details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return specific employee details</returns>
        Employees GetEmployeeById(int id);

        /// <summary>
        ///  Method for adding new Employee
        /// </summary>
        /// <param name="info"> stores the Complete Employee information</param>
        /// <returns>return extra employee details</returns>       
        Employees AddEmployeeDetails(Employees info);

        /// <summary>
        /// Method for updating previous employee details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <param name="info">for getting updatable details</param>
        /// <returns>returns updated details</returns>
        Employees UpdateEmployeeDetails(int id, Employees info);

        /// <summary>
        /// Method for Deleting specific Employee Details 
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return deleted record</returns>
        int DeleteEmployeeById(int id);
    }
}