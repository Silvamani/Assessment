export interface EmployeeListInterface {
    id: number,
    employeeID: string,
    employeeName: string,
    phoneNumber: string,
    email: string,
    address: string,
    designation: string,
    workHour: 0
}


export interface DesignationListInterface {
    id: number,
    designationName: string,
    employeeCount: number
}

export interface TimeManagementInterface {
    id: number,
    insertionDate: string,
    monthlyTotalHour: number,
    monthlyMinHour: number
}

export interface GetAllEmployeeIdInterface {
    employeeId: string
}
