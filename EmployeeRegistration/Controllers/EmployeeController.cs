﻿//-----------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace EmployeeRegistration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommanLayer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Contoller Class for User
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// for configuration
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// instance of employee interface
        /// </summary>
        private IEmployeeBL businessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController" /> class.
        /// </summary>
        /// <param name="businessDependencyInjection">dependency injection</param>
        /// <param name="config">for configuration</param>
        public EmployeeController(IEmployeeBL businessDependencyInjection, IConfiguration config)
        {
            this.businessLayer = businessDependencyInjection;
            this.config = config;
        }

        /// <summary>
        /// Method to get all employee Details
        /// </summary>
        /// <returns>return all employee details</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Employees>> GetAllemployee()
        {
            try
            {
                var result = this.businessLayer.GetAllemployee();

                // if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    string status = "Success";
                    string message = "Employee Data found ";
                    return this.Ok(new { status, message, Data = result });
                }
                else                                         
                {
                    string status = "Unsuccess";
                    string message = "Employee Data is Not found";
                    return this.BadRequest(new { status, message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for Getting specific Employee Details
        /// </summary>
        /// <param name="id">for specific Employee</param>
        /// <returns>return specific Employee Details</returns>
        [HttpGet("{id}")]
        public ActionResult GetSpecificEmployeeDetails([FromRoute] int id)
        {
            try
            {
                var result = this.businessLayer.GetSpecificEmployeeDetails(id);

                // if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    string status = "Success";
                    string message = "Employee Data found ";
                    return this.Ok(new { status, message, Data = result });
                }
                else
                {
                    string status = "Unsuccess";
                    string message = "Employee Data is Not found";
                    return this.BadRequest(new { status, message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  Method for adding new Employee
        /// </summary>
        /// <param name="info"> stores the Complete Employee information</param>
        /// <returns>return extra employee details</returns>       
        [HttpPost]
        public async Task<IActionResult> AddEmployeeDetails([FromBody] Employees info)
        {
            try
            {
                bool data = await this.businessLayer.AddEmployeeDetails(info);

                // if data is not equal to null then Registration sucessful
                if (!data.Equals(null))
                {
                    string status = "Success";
                    string message = "Added Successfuly";
                    return this.Ok(new { status, message, info });
                }
                else
                {
                    string status = "UnSuccess";
                    string message = "Adding is Failed";
                    return this.BadRequest(new { status, message, data = info });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error = e.Message });
            }
        }

        /// <summary>
        /// Method for updating specific record
        /// </summary>
        /// <param name="id">for define specific record</param>
        /// <param name="info">collecting specific employee details</param>
        /// <returns>return specific Employee details updated</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateEmployeeDetails([FromRoute] int id, [FromBody] Employees info)
        {
            try
            {
                var response = this.businessLayer.UpdateEmployeeDetails(id, info);
                if (!response.Equals(null))
                {
                    string status = "Success";
                    string message = "Employee Data Updated Sucessfully";
                    return this.Ok(new { status, message, data = info });
                }
                else
                {
                    string status = "Unsuccess";
                    string message = "Employee Data not Updated";
                    return this.BadRequest(new { status, message, data = info });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error = e.Message });
            }
        }

        /// <summary>
        /// Method for Deleting specific Employee Details 
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return deleted record</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployeeDetails([FromRoute] int id)
        {
            try
            {
                var response = this.businessLayer.DeleteEmployeeDetails(id);
                if (!response.Equals(null))
                {
                    string status = "Success";
                    string message = "Employee Data Sucessfully Deleted";
                    return this.Ok(new { status, message });
                }
                else
                {
                    string status = "Unsuccess";
                    string message = "Employee Data Not Deleted";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error = e.Message });
            }
        }
    }
}