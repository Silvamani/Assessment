import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class DataService {

    constructor(private httpClient: HttpClient) { }

    // Authentication

    SignUp(UserName: string, Password: string) {

        const data = JSON.stringify({
            password: Password,
            userName: UserName
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Auth/SignUp', data, options)
    }

    SignIn(UserName: string, Password: string) {

        const data = JSON.stringify({
            password: Password,
            userName: UserName
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Auth/SignIn', data, options)
    }

    // Employee

    AddEmployee(EmployeeID: string, EmployeeName: string, PhoneNumber: string, Email: string, Address: string, DesignationId: string) {

        const data = JSON.stringify({
            employeeID: EmployeeID,
            employeeName: EmployeeName,
            phoneNumber: PhoneNumber,
            email: Email,
            address: Address,
            designationId: DesignationId
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Employee/AddEmployee', data, options)
    }

    UpdateEmployee(Id: number, EmployeeID: string, EmployeeName: string, PhoneNumber: string, Email: string, Address: string, DesignationId: string) {

        const data = JSON.stringify({
            id: Id,
            employeeID: EmployeeID,
            employeeName: EmployeeName,
            phoneNumber: PhoneNumber,
            email: Email,
            address: Address,
            designationId: DesignationId
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.patch(environment.BEServer.DevEnviroment + 'api/Employee/UpdateEmployee', data, options)
    }

    GetEmployee(PageNumber: number, NumberOfRecordPerPage: number) {

        // const data = JSON.stringify({
        //     employeeID: EmployeeID,
        //     employeeName: EmployeeName,
        //     phoneNumber: PhoneNumber,
        //     email: Email,
        //     address: Address
        // })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Employee/GetEmployee?PageNumber=' + PageNumber + '&NumberOfRecordPerPage=' + NumberOfRecordPerPage, options)
    }

    GetAllDesignation() {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Designation/GetAllDesignation', options)
    }

    GetAllEmployeeId() {
        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Employee/GetAllEmployeeId', options)
    }

    DeleteEmployee(ID: number) {

        // debugger
        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient
            .delete(environment.BEServer.DevEnviroment + 'api/Employee/DeleteEmployee?Id=' + ID, options)
    }

    // Designation

    AddDesignation(DesignationName: string) {
        debugger
        const data = JSON.stringify({
            designationName: DesignationName
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Designation/AddDesignation', data, options)
    }

    UpdateDesignation(Id: number, DesignationName: string) {
        // debugger
        const data = JSON.stringify({
            id: Id,
            designationName: DesignationName,
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.patch(environment.BEServer.DevEnviroment + 'api/Designation/UpdateDesignation', data, options)
    }

    GetDesignation(PageNumber: number, NumberOfRecordPerPage: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Designation/GetDesignation?PageNumber=' + PageNumber + '&NumberOfRecordPerPage=' + NumberOfRecordPerPage, options)
    }

    DeleteDesignation(ID: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient
            .delete(environment.BEServer.DevEnviroment + 'api/Designation/DeleteDesignation?Id=' + ID, options)
    }

    // HoursManagement

    AddHours(TotalHours: number, MinHours: number) {

        const data = JSON.stringify({
            totalHours: TotalHours,
            minHours: MinHours
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/HourManagement/AddHours', data, options)
    }

    UpdateHours(Id: number, TotalHours: number, MinHours: number) {

        const data = JSON.stringify({
            id: Id,
            totalHours: TotalHours,
            minHours: MinHours
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.patch(environment.BEServer.DevEnviroment + 'api/HourManagement/UpdateHours', data, options)
    }

    GetHours() {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/HourManagement/GetHours', options)
    }

    DeleteHours(ID: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient
            .delete(environment.BEServer.DevEnviroment + 'api/HourManagement/DeleteHours?Id=' + ID, options)
    }

    // Leave

    AddLeave(EmployeeId: string, Type: string, FromLeaveDate: string, ToLeaveDate: string, Reason: any) {

        const data = JSON.stringify({
            employeeId: EmployeeId,
            type: Type,
            fromleaveDate: FromLeaveDate,
            toleaveDate: ToLeaveDate,
            reason: Reason
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Leave/AddLeaveDetail', data, options)
    }

    UpdateLeave(Id: number, EmployeeId: string, Type: string, FromLeaveDate: string, ToLeaveDate: string, Reason: any) {

        const data = JSON.stringify({
            id: Id,
            employeeId: EmployeeId,
            type: Type,
            fromleaveDate: FromLeaveDate,
            toleaveDate: ToLeaveDate,
            reason: Reason
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.patch(environment.BEServer.DevEnviroment + 'api/Leave/UpdateLeaveDetail', data, options)
    }

    GetLeave(PageNumber: number, NumberOfRecordPerPage: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Leave/GetLeaveDetail?PageNumber=' + PageNumber + '&NumberOfRecordPerPage=' + NumberOfRecordPerPage, options)
    }

    DeleteLeave(ID: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient
            .delete(environment.BEServer.DevEnviroment + 'api/Leave/DeleteLeaveDetail?Id=' + ID, options)
    }

    // Payment

    AddPayment(DesignationID: string, PaymentAmount: number) {

        const data = JSON.stringify({
            designationID: DesignationID,
            paymentAmount: PaymentAmount
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.post(environment.BEServer.DevEnviroment + 'api/Payment/AddPaymentDetail', data, options)
    }

    UpdatePayment(Id: number, DesignationID: string, PaymentAmount: number) {

        const data = JSON.stringify({
            id: Id,
            designationID: DesignationID,
            paymentAmount: PaymentAmount
        })

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient.patch(environment.BEServer.DevEnviroment + 'api/Payment/UpdatePaymentDetail', data, options)
    }

    GetPayment(PageNumber: number, NumberOfRecordPerPage: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this
            .httpClient
            .get(environment.BEServer.DevEnviroment + 'api/Payment/GetPaymentDetail?PageNumber=' + PageNumber + '&NumberOfRecordPerPage=' + NumberOfRecordPerPage, options)
    }

    DeletePayment(ID: number) {

        const httpHeaders = new HttpHeaders({
            'content-type': 'application/json',
            'cache-control': 'no-cache'
        })

        const options = {
            headers: httpHeaders
        };

        return this.httpClient
            .delete(environment.BEServer.DevEnviroment + 'api/Payment/DeletePaymentDetail?Id=' + ID, options)
    }

}