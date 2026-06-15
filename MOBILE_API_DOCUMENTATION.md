# MOBILE API DOCUMENTATION
This document provides complete integration details for the Flutter mobile application to interact with the production backend.

## Production Environment
**Base URL:** `http://167.71.45.248`
All endpoints must be prefixed with this base URL.

## Authentication
The API uses JWT Bearer Authentication.
Include the following header in authenticated requests:
```http
Authorization: Bearer {token}
```
- **Where token comes from:** Returned in the response of the Login and Register endpoints.
- **When it expires:** Access tokens usually expire in 60 minutes. Use the `refreshToken` to get a new access token.
- **Which endpoints require it:** Documented under each endpoint below (look for 'Requires Auth').

## API Endpoints
### Appointments
#### `POST` `/api/Appointments/book`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.BookAppointmentRequest`
**Example Request:**
```json
{
  "doctorId": "string",
  "appointmentDate": "string",
  "appointmentTime": "string",
  "consultationType": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `409`: Conflict
  - `500`: Internal Server Error
---
#### `GET` `/api/Appointments/{appointmentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Appointments/{appointmentId}/start-session`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.SessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `409`: Conflict
---
#### `GET` `/api/Appointments/{appointmentId}/session`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.SessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Appointments/{appointmentId}/end-session`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.EndSessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `POST` `/api/Appointments/{appointmentId}/documentation`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Documentation.SaveDocumentationRequest`
**Example Request:**
```json
{
  "chiefComplaint": "string",
  "historyOfPresentIllness": "string",
  "physicalExamination": "string",
  "diagnosis": "string",
  "managementPlan": "string",
  "sessionType": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
---
#### `PUT` `/api/Appointments/{appointmentId}/documentation`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Documentation.SaveDocumentationRequest`
**Example Request:**
```json
{
  "chiefComplaint": "string",
  "historyOfPresentIllness": "string",
  "physicalExamination": "string",
  "diagnosis": "string",
  "managementPlan": "string",
  "sessionType": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
---
#### `GET` `/api/Appointments/{appointmentId}/documentation`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
  - `403`: Forbidden
---
#### `POST` `/api/Appointments/{appointmentId}/prescription`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Prescription.CreatePrescriptionRequest`
**Example Request:**
```json
{
  "appointmentId": "string",
  "doctorId": "string",
  "patientId": "string",
  "prescriptionNumber": "string",
  "digitalSignature": "string",
  "generalInstructions": "string",
  "prescribedMedications": []
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
---
#### `GET` `/api/Appointments/{appointmentId}/prescription`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
### Auth
#### `POST` `/api/Auth/register/patient`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.RegisterPatientRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/register/doctor`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.RegisterDoctorRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string",
  "medicalSpecialty": {}
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/register/verifier`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.RegisterVerifierRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `403`: Forbidden
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/verify-email`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.VerifyEmailRequest`
**Example Request:**
```json
{
  "email": "string",
  "otpCode": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/resend-verification`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.ResendOtpRequest`
**Example Request:**
```json
{
  "email": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `429`: Too Many Requests
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/login`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.LoginRequest`
**Example Request:**
```json
{
  "email": "string",
  "password": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/google`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.GoogleLoginRequest`
**Example Request:**
```json
{
  "idToken": "string",
  "userType": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `201`: Created
  - `404`: Not Found
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/forgot-password`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.ForgotPasswordRequest`
**Example Request:**
```json
{
  "email": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `429`: Too Many Requests
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/reset-password`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.VerifyResetOtpRequest`
**Example Request:**
```json
{
  "email": "string",
  "otpCode": "string",
  "newPassword": "string",
  "confirmPassword": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/change-password`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.ChangePasswordRequest`
**Example Request:**
```json
{
  "currentPassword": "string",
  "newPassword": "string",
  "confirmNewPassword": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/refresh-token`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.RefreshTokenRequest`
**Example Request:**
```json
{
  "accessToken": "string",
  "refreshToken": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Auth/logout`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.RefreshTokenRequest`
**Example Request:**
```json
{
  "accessToken": "string",
  "refreshToken": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `DELETE` `/api/Auth/debug/delete-account-by-email`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.DeleteAccountRequest`
**Example Request:**
```json
{
  "email": "string",
  "password": "string",
  "confirmationText": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `DELETE` `/api/Auth/delete-account`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Auth.DeleteAccountRequest`
**Example Request:**
```json
{
  "email": "string",
  "password": "string",
  "confirmationText": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `404`: Not Found
  - `500`: Internal Server Error
---
### Clinics
#### `GET` `/api/Doctors/me/clinic/info`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicInfoResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `PUT` `/api/Doctors/me/clinic/info`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Clinic.UpdateClinicInfoRequest`
**Example Request:**
```json
{
  "clinicName": "string",
  "phoneNumbers": [],
  "services": []
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicInfoResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/Doctors/me/clinic/address`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `PUT` `/api/Doctors/me/clinic/address`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Clinic.UpdateClinicAddressRequest`
**Example Request:**
```json
{
  "governorate": "string",
  "city": "string",
  "street": "string",
  "buildingNumber": "string",
  "latitude": 0,
  "longitude": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/Doctors/me/clinic/images`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicImagesListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Doctors/me/clinic/images`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicImageResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `DELETE` `/api/Doctors/me/clinic/images/{imageId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `imageId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
  - `500`: Internal Server Error
---
### Debug
#### `GET` `/api/debug/fix-verifier`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
---
### Diagnosis
#### `POST` `/api/doctor/Diagnosis`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Diagnosis.DiagnosisRequestDto`
**Example Request:**
```json
{
  "patientId": "string",
  "symptomsText": "string",
  "evidenceCodes": "string",
  "age": 0,
  "sex": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Diagnosis.DiagnosisResponseDto`
**Example Response:**
```json
{
  "patientId": "string",
  "originalSymptoms": "string",
  "normalizedSymptoms": "string",
  "suggestedDiagnosis": "string",
  "topResults": [],
  "confidenceLevel": 0,
  "generatedAt": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
---
#### `GET` `/api/doctor/Diagnosis/health`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
---
### DoctorDashboard
#### `GET` `/api/doctors/me/dashboard/stats`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDashboardStatsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/me/dashboard/appointments`
- **Authorization Requirement:** No
- **Parameters:**
  - `StartDate` (query): string (date-time) - Optional
  - `EndDate` (query): string (date-time) - Optional
  - `Status` (query): Nabd.Core.Enums.Appointments.AppointmentStatus - Optional
  - `SortBy` (query): string - Optional
  - `SortOrder` (query): string - Optional
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/doctors/me/dashboard/appointments/today`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
### DoctorDocuments
#### `GET` `/api/doctors/me/documents/{documentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `documentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/me/documents/required`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/doctors/me/documents/required`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `GET` `/api/doctors/me/documents/research`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/doctors/me/documents/research`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
---
#### `GET` `/api/doctors/me/documents/awards`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/doctors/me/documents/awards`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
---
### DoctorPatients
#### `GET` `/api/doctors/me/patients`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/me/patients/{patientId}/medical-record`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientMedicalRecordResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/me/patients/{patientId}/session-documentations`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientSessionDocumentationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/me/patients/{patientId}/prescriptions`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionsListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
### DoctorReviews
#### `GET` `/api/Doctors/me/reviews`
- **Authorization Requirement:** No
- **Parameters:**
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `400`: Bad Request
---
#### `GET` `/api/Doctors/me/reviews/statistics`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewStatisticsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/Doctors/me/reviews/{id}/details`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewDetailsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `POST` `/api/Doctors/me/reviews/{reviewId}/reply`
- **Authorization Requirement:** No
- **Parameters:**
  - `reviewId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Review.ReplyToReviewRequest`
**Example Request:**
```json
{
  "reply": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewDetailsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `400`: Bad Request
  - `404`: Not Found
---
### Doctors
#### `GET` `/api/Doctors/me`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `GET` `/api/Doctors/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `PUT` `/api/Doctors/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Doctor.UpdateDoctorProfileRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "profileImage": "string",
  "gender": {},
  "dateOfBirth": "string",
  "medicalSpecialty": {},
  "yearsOfExperience": 0,
  "biography": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
#### `GET` `/api/Doctors/profile/personal`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPersonalProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `PUT` `/api/Doctors/profile/personal`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Doctor.UpdatePersonalInfoRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "dateOfBirth": "string",
  "gender": {},
  "biography": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `GET` `/api/Doctors/profile/professional`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfessionalInfoResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `GET` `/api/Doctors/profile/specialty-experience`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorSpecialtyExperienceResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `PUT` `/api/Doctors/profile/specialty-experience`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Doctor.UpdateSpecialtyExperienceRequest`
**Example Request:**
```json
{
  "medicalSpecialty": {},
  "yearsOfExperience": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorSpecialtyExperienceResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `PUT` `/api/Doctors/me/profile-image`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `GET` `/api/Doctors/list`
- **Authorization Requirement:** No
- **Parameters:**
  - `SearchTerm` (query): string - Optional
  - `Specialty` (query): Nabd.Core.Enums.Doctor.MedicalSpecialty - Optional
  - `MedicalSpecialty` (query): Nabd.Core.Enums.Doctor.MedicalSpecialty - Optional
  - `Governorate` (query): Nabd.Core.Enums.Governorate - Optional
  - `City` (query): string - Optional
  - `MinRating` (query): number (double) - Optional
  - `MinPrice` (query): number (double) - Optional
  - `MaxPrice` (query): number (double) - Optional
  - `AvailableToday` (query): boolean - Optional
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Doctors/{doctorId}/details`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDetailsWithClinicResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Doctors/me/submit-for-review`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `404`: Not Found
---
#### `GET` `/api/Doctors/specialty/all`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.SpecialtyResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
### DoctorSchedule
#### `GET` `/api/doctors/{doctorId}/appointments/schedule`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Appointment.DayScheduleSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/{doctorId}/appointments/exceptions`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/{doctorId}/services`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorServicesResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/doctors/{doctorId}/appointments/booked`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
  - `date` (query): string - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `GET` `/api/doctors/{doctorId}/appointments/available-slots`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
  - `date` (query): string - Optional
  - `consultationType` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.AvailableTimeSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
### DoctorServices
#### `GET` `/api/Doctors/me/services/regular-checkup`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `PUT` `/api/Doctors/me/services/regular-checkup`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Clinic.UpdateServicePricingRequest`
**Example Request:**
```json
{
  "price": 0,
  "duration": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/Doctors/me/services/re-examination`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `PUT` `/api/Doctors/me/services/re-examination`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Clinic.UpdateServicePricingRequest`
**Example Request:**
```json
{
  "price": 0,
  "duration": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/Doctors/me/appointments/schedule`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `PUT` `/api/Doctors/me/appointments/schedule`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.UpdateWeeklyScheduleRequest`
**Example Request:**
```json
{
  "weeklySchedule": {}
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/Doctors/me/appointments/exceptions`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDatesListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Doctors/me/appointments/exceptions`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.AddExceptionalDateRequest`
**Example Request:**
```json
{
  "date": "string",
  "fromTime": "string",
  "toTime": "string",
  "fromPeriod": "string",
  "toPeriod": "string",
  "isClosed": false
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `DELETE` `/api/Doctors/me/appointments/exceptions/{exceptionId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `exceptionId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
  - `500`: Internal Server Error
---
### DoctorSessions
#### `GET` `/api/doctors/me/sessions/active`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.SessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
### Notifications
#### `GET` `/api/Notifications/unread`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Notifications`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Notifications/unread-count`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.API.Controllers.UnreadCountResponse, Nabd.API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `PUT` `/api/Notifications/{notificationId}/mark-as-read`
- **Authorization Requirement:** No
- **Parameters:**
  - `notificationId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `PUT` `/api/Notifications/mark-all-as-read`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `DELETE` `/api/Notifications/{notificationId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `notificationId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Notifications/debug/test-send`
- **Authorization Requirement:** No
- **Parameters:**
  - `targetUserId` (query): string (uuid) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
### PatientAppointments
#### `GET` `/api/patients/me/appointments`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `POST` `/api/patients/me/appointments`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.CreateAppointmentRequest`
**Example Request:**
```json
{
  "patientId": "string",
  "doctorId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {}
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "patientId": "string",
  "doctorId": "string",
  "previousAppointmentId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "consultationFee": 0,
  "sessionDurationMinutes": 0,
  "status": {},
  "cancellationReason": "string",
  "cancelledAt": "string",
  "actualStartTime": "string",
  "actualEndTime": "string",
  "patientName": "string",
  "patientAge": 0,
  "patientProfileImageUrl": "string",
  "prescriptionId": "string",
  "patient": {},
  "doctor": {},
  "consultationRecord": {}
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `403`: Forbidden
---
#### `GET` `/api/patients/me/appointments/{appointmentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "patientId": "string",
  "doctorId": "string",
  "previousAppointmentId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "consultationFee": 0,
  "sessionDurationMinutes": 0,
  "status": {},
  "cancellationReason": "string",
  "cancelledAt": "string",
  "actualStartTime": "string",
  "actualEndTime": "string",
  "patientName": "string",
  "patientAge": 0,
  "patientProfileImageUrl": "string",
  "prescriptionId": "string",
  "patient": {},
  "doctor": {},
  "consultationRecord": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
  - `403`: Forbidden
---
#### `PUT` `/api/patients/me/appointments/{appointmentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.UpdateAppointmentRequest`
**Example Request:**
```json
{
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "status": {},
  "cancellationReason": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "patientId": "string",
  "doctorId": "string",
  "previousAppointmentId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "consultationFee": 0,
  "sessionDurationMinutes": 0,
  "status": {},
  "cancellationReason": "string",
  "cancelledAt": "string",
  "actualStartTime": "string",
  "actualEndTime": "string",
  "patientName": "string",
  "patientAge": 0,
  "patientProfileImageUrl": "string",
  "prescriptionId": "string",
  "patient": {},
  "doctor": {},
  "consultationRecord": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
#### `DELETE` `/api/patients/me/appointments/{appointmentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Status Codes:**
  - `204`: No Content
  - `403`: Forbidden
  - `404`: Not Found
---
#### `GET` `/api/patients/me/appointments/upcoming`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/patients/me/appointments/past`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/patients/me/appointments/status/{status}`
- **Authorization Requirement:** No
- **Parameters:**
  - `status` (path): Nabd.Core.Enums.Appointments.AppointmentStatus - Required
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/patients/me/appointments/date-range`
- **Authorization Requirement:** No
- **Parameters:**
  - `startDate` (query): string (date-time) - Optional
  - `endDate` (query): string (date-time) - Optional
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
---
#### `GET` `/api/patients/me/appointments/count`
- **Authorization Requirement:** No
- **Response Schema:** `object`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/patients/me/appointments/check-availability`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (query): string (uuid) - Optional
  - `startTime` (query): string (date-time) - Optional
  - `endTime` (query): string (date-time) - Optional
- **Response Schema:** `object`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `PATCH` `/api/patients/me/appointments/{appointmentId}/cancel`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.CancelAppointmentRequest`
**Example Request:**
```json
{
  "cancellationReason": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "patientId": "string",
  "doctorId": "string",
  "previousAppointmentId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "consultationFee": 0,
  "sessionDurationMinutes": 0,
  "status": {},
  "cancellationReason": "string",
  "cancelledAt": "string",
  "actualStartTime": "string",
  "actualEndTime": "string",
  "patientName": "string",
  "patientAge": 0,
  "patientProfileImageUrl": "string",
  "prescriptionId": "string",
  "patient": {},
  "doctor": {},
  "consultationRecord": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
#### `PATCH` `/api/patients/me/appointments/{appointmentId}/reschedule`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Appointment.RescheduleAppointmentRequest`
**Example Request:**
```json
{
  "newScheduledStartTime": "string",
  "newScheduledEndTime": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "patientId": "string",
  "doctorId": "string",
  "previousAppointmentId": "string",
  "scheduledStartTime": "string",
  "scheduledEndTime": "string",
  "consultationType": {},
  "consultationFee": 0,
  "sessionDurationMinutes": 0,
  "status": {},
  "cancellationReason": "string",
  "cancelledAt": "string",
  "actualStartTime": "string",
  "actualEndTime": "string",
  "patientName": "string",
  "patientAge": 0,
  "patientProfileImageUrl": "string",
  "prescriptionId": "string",
  "patient": {},
  "doctor": {},
  "consultationRecord": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
### PatientMedical
#### `GET` `/api/Patients/me/medical-history`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Patient.MedicalHistoryItemResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Patients/me/medical-history`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Patient.CreateMedicalHistoryItemRequest`
**Example Request:**
```json
{
  "type": {},
  "text": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Patient.MedicalHistoryItemResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "type": {},
  "text": "string",
  "patientId": "string"
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `404`: Not Found
---
#### `PUT` `/api/Patients/me/medical-history/{itemId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `itemId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Patient.UpdateMedicalHistoryItemRequest`
**Example Request:**
```json
{
  "type": {},
  "text": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Patient.MedicalHistoryItemResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "type": {},
  "text": "string",
  "patientId": "string"
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `404`: Not Found
---
#### `DELETE` `/api/Patients/me/medical-history/{itemId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `itemId` (path): string (uuid) - Required
- **Status Codes:**
  - `204`: No Content
  - `404`: Not Found
---
#### `GET` `/api/Patients/me/prescriptions`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Patients/me/prescriptions/active`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Patients/me/prescriptions/{prescriptionId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `prescriptionId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "prescriptionNumber": "string",
  "digitalSignature": "string",
  "appointmentId": "string",
  "doctorId": "string",
  "patientId": "string",
  "generalInstructions": "string",
  "status": {},
  "dispensedAt": "string",
  "cancellationReason": "string",
  "cancelledAt": "string",
  "doctor": {},
  "patient": {},
  "prescribedMedications": []
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Patients/me/prescriptions/list`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Prescription.PatientPrescriptionListResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
  - `500`: Internal Server Error
---
### PatientProfile
#### `GET` `/api/Patients/me/profile`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `PUT` `/api/Patients/me/profile`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Patient.UpdatePatientRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "birthDate": "string",
  "gender": {}
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `GET` `/api/Patients/me/address`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Address.AddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `PUT` `/api/Patients/me/address`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Common.Address.UpdateAddressRequest`
**Example Request:**
```json
{
  "street": "string",
  "city": "string",
  "governorate": {},
  "buildingNumber": "string",
  "latitude": 0,
  "longitude": 0
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Address.AddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `GET` `/api/Patients/me/medical-record`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.MedicalRecordResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `PUT` `/api/Patients/me/medical-record`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Patient.UpdateMedicalRecordRequest`
**Example Request:**
```json
{
  "drugAllergies": [],
  "chronicDiseases": [],
  "currentMedications": [],
  "previousSurgeries": []
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.MedicalRecordResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `PUT` `/api/Patients/me/profile-image`
- **Authorization Requirement:** No
- **Request Body Schema:** `multipart/form-data`
**Content-Type:** `multipart/form-data`
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `DELETE` `/api/Patients/me/profile-image`
- **Authorization Requirement:** No
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
### PatientReviews
#### `POST` `/api/patients/me/reviews`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Review.CreateDoctorReviewRequest`
**Example Request:**
```json
{
  "appointmentId": "string",
  "overallSatisfaction": 0,
  "waitingTime": 0,
  "communicationQuality": 0,
  "clinicCleanliness": 0,
  "valueForMoney": 0,
  "comment": "string",
  "isAnonymous": false
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `GET` `/api/patients/me/reviews/doctors/{doctorId}/reviews`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `GET` `/api/patients/me/reviews/doctors/{doctorId}/reviews/statistics`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewStatisticsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
### Patients
#### `GET` `/api/Patients/test`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
---
#### `POST` `/api/Patients`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Patient.CreatePatientRequest`
**Example Request:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Responses.Patient.PatientResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "firstName": "string",
  "lastName": "string",
  "fullName": "string",
  "email": "string",
  "phoneNumber": "string",
  "birthDate": "string",
  "gender": {},
  "profileImageUrl": "string",
  "address": {},
  "medicalHistory": []
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
---
#### `GET` `/api/Patients`
- **Authorization Requirement:** No
- **Parameters:**
  - `includeDeleted` (query): boolean - Optional
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Patient.PatientResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
---
#### `DELETE` `/api/Patients/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Status Codes:**
  - `204`: No Content
  - `404`: Not Found
---
#### `POST` `/api/Patients/{id}/restore`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Patients/email/{email}`
- **Authorization Requirement:** No
- **Parameters:**
  - `email` (path): string - Required
- **Response Schema:** `Nabd.Application.DTOs.Responses.Patient.PatientResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "firstName": "string",
  "lastName": "string",
  "fullName": "string",
  "email": "string",
  "phoneNumber": "string",
  "birthDate": "string",
  "gender": {},
  "profileImageUrl": "string",
  "address": {},
  "medicalHistory": []
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Patients/paginated`
- **Authorization Requirement:** No
- **Parameters:**
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "pageNumber": 0,
  "pageSize": 0,
  "totalCount": 0,
  "totalPages": 0,
  "hasPreviousPage": false,
  "hasNextPage": false,
  "data": [],
  "statistics": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `GET` `/api/Patients/search`
- **Authorization Requirement:** No
- **Parameters:**
  - `SearchTerm` (query): string - Optional
  - `Gender` (query): Nabd.Core.Enums.Identity.Gender - Optional
  - `BirthDateFrom` (query): string (date) - Optional
  - `BirthDateTo` (query): string (date) - Optional
  - `HasMedicalHistory` (query): boolean - Optional
  - `HasUpcomingAppointments` (query): boolean - Optional
  - `City` (query): string - Optional
  - `SortBy` (query): Nabd.Application.DTOs.Requests.Patient.PatientSortBy - Optional
  - `SortDescending` (query): boolean - Optional
  - `RegisteredFrom` (query): string (date-time) - Optional
  - `RegisteredTo` (query): string (date-time) - Optional
  - `IsActive` (query): boolean - Optional
  - `LastActivityFrom` (query): string (date-time) - Optional
  - `LastActivityTo` (query): string (date-time) - Optional
  - `PageNumber` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "pageNumber": 0,
  "pageSize": 0,
  "totalCount": 0,
  "totalPages": 0,
  "hasPreviousPage": false,
  "hasNextPage": false,
  "data": [],
  "statistics": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
---
#### `GET` `/api/Patients/with-medical-history`
- **Authorization Requirement:** No
- **Response Schema:** `Array<Nabd.Application.DTOs.Responses.Patient.PatientResponse>`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Patients/check-email/{email}`
- **Authorization Requirement:** No
- **Parameters:**
  - `email` (path): string - Required
- **Response Schema:** `object`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Patients/count`
- **Authorization Requirement:** No
- **Parameters:**
  - `includeDeleted` (query): boolean - Optional
- **Response Schema:** `object`
**Example Response:**
```json
{}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Patients/current/{userId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `userId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Responses.Patient.PatientResponse`
**Example Response:**
```json
{
  "id": "string",
  "createdAt": "string",
  "createdBy": "string",
  "updatedAt": "string",
  "updatedBy": "string",
  "firstName": "string",
  "lastName": "string",
  "fullName": "string",
  "email": "string",
  "phoneNumber": "string",
  "birthDate": "string",
  "gender": {},
  "profileImageUrl": "string",
  "address": {},
  "medicalHistory": []
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
### Payments
#### `POST` `/api/Payments/appointments/{appointmentId}/initiate`
- **Authorization Requirement:** No
- **Parameters:**
  - `appointmentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Payment.InitiateAppointmentPaymentRequest`
**Example Request:**
```json
{
  "paymentMethod": {},
  "paymentType": {}
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
#### `POST` `/api/Payments/webhook/paymob`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
---
#### `GET` `/api/Payments/{paymentId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `paymentId` (path): string (uuid) - Required
- **Status Codes:**
  - `200`: OK
  - `403`: Forbidden
  - `404`: Not Found
---
#### `POST` `/api/Payments/{paymentId}/cancel`
- **Authorization Requirement:** No
- **Parameters:**
  - `paymentId` (path): string (uuid) - Required
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `403`: Forbidden
  - `404`: Not Found
---
#### `POST` `/api/Payments/{paymentId}/test-success`
- **Authorization Requirement:** No
- **Parameters:**
  - `paymentId` (path): string (uuid) - Required
- **Status Codes:**
  - `200`: OK
---
### Prescriptions
#### `GET` `/api/Prescriptions`
- **Authorization Requirement:** No
- **Parameters:**
  - `Page` (query): integer (int32) - Optional
  - `PageSize` (query): integer (int32) - Optional
  - `PatientId` (query): string (uuid) - Optional
  - `DoctorId` (query): string (uuid) - Optional
  - `PharmacyId` (query): string (uuid) - Optional
  - `MedicationId` (query): string (uuid) - Optional
  - `AppointmentId` (query): string (uuid) - Optional
  - `Status` (query): Nabd.Core.Enums.PrescriptionStatus - Optional
  - `StartDate` (query): string (date-time) - Optional
  - `EndDate` (query): string (date-time) - Optional
  - `SearchTerm` (query): string - Optional
  - `SortBy` (query): string - Optional
  - `SortDescending` (query): boolean - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionQueryResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
#### `POST` `/api/Prescriptions`
- **Authorization Requirement:** No
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Prescription.CreatePrescriptionRequest`
**Example Request:**
```json
{
  "appointmentId": "string",
  "doctorId": "string",
  "patientId": "string",
  "prescriptionNumber": "string",
  "digitalSignature": "string",
  "generalInstructions": "string",
  "prescribedMedications": []
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `PUT` `/api/Prescriptions/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Prescription.UpdatePrescriptionRequest`
**Example Request:**
```json
{
  "generalInstructions": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `DELETE` `/api/Prescriptions/{id}`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/number/{prescriptionNumber}`
- **Authorization Requirement:** No
- **Parameters:**
  - `prescriptionNumber` (path): string - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `POST` `/api/Prescriptions/{id}/cancel`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Prescription.CancelPrescriptionRequest`
**Example Request:**
```json
{
  "reason": "string",
  "notes": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `POST` `/api/Prescriptions/{id}/renew`
- **Authorization Requirement:** No
- **Parameters:**
  - `id` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Prescription.RenewPrescriptionRequest`
**Example Request:**
```json
{
  "generalInstructions": "string",
  "durationInDays": 0,
  "renewalReason": "string",
  "copyAllMedications": false,
  "newAppointmentId": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `201`: Created
  - `400`: Bad Request
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/patient/{patientId}/current-medications`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.CurrentMedicationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/patient/{patientId}/doctor/{doctorId}/prescription/{prescriptionId}`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
  - `doctorId` (path): string (uuid) - Required
  - `prescriptionId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionDetailedResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `403`: Forbidden
  - `404`: Not Found
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/patient/{patientId}/doctor/{doctorId}/list`
- **Authorization Requirement:** No
- **Parameters:**
  - `patientId` (path): string (uuid) - Required
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `403`: Forbidden
  - `500`: Internal Server Error
---
#### `GET` `/api/Prescriptions/medications`
- **Authorization Requirement:** No
- **Parameters:**
  - `search` (query): string - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.MedicationNameResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
  - `500`: Internal Server Error
---
### Seed
#### `POST` `/api/Seed/seed`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
---
#### `POST` `/api/Seed/clear`
- **Authorization Requirement:** No
- **Status Codes:**
  - `200`: OK
---
### Verifier
#### `POST` `/api/Verifier/doctors/{doctorId}/start-review`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Verifier/doctors/{doctorId}/verify`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
  - `401`: Unauthorized
---
#### `POST` `/api/Verifier/doctors/{doctorId}/reject`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `GET` `/api/Verifier/doctors/status/sent`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Verifier/doctors/status/under-review`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Verifier/doctors/status/verified`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `401`: Unauthorized
---
#### `GET` `/api/Verifier/doctors/status/rejected`
- **Authorization Requirement:** No
- **Parameters:**
  - `pageNumber` (query): integer (int32) - Optional
  - `pageSize` (query): integer (int32) - Optional
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
---
#### `GET` `/api/Verifier/doctors/{doctorId}/documents`
- **Authorization Requirement:** No
- **Parameters:**
  - `doctorId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": [],
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Verifier/documents/{documentId}/approve`
- **Authorization Requirement:** No
- **Parameters:**
  - `documentId` (path): string (uuid) - Required
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
#### `POST` `/api/Verifier/documents/{documentId}/reject`
- **Authorization Requirement:** No
- **Parameters:**
  - `documentId` (path): string (uuid) - Required
- **Request Body Schema:** `Nabd.Application.DTOs.Requests.Verifier.RejectDocumentRequest`
**Example Request:**
```json
{
  "rejectionReason": "string"
}
```
- **Response Schema:** `Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]`
**Example Response:**
```json
{
  "isSuccess": false,
  "message": "string",
  "data": {},
  "errors": "string",
  "statusCode": 0
}
```
- **Status Codes:**
  - `200`: OK
  - `404`: Not Found
---
## DTO Reference
```text
Microsoft.AspNetCore.Mvc.ProblemDetails
├── type : string (optional)
├── title : string (optional)
├── status : integer (int32) (optional)
├── detail : string (optional)
├── instance : string (optional)
```
```text
Nabd.API.Controllers.UnreadCountResponse
├── count : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Address.AddressResponse
├── street : string (optional)
├── city : string (optional)
├── governorate : Nabd.Core.Enums.Governorate (optional)
├── buildingNumber : string (optional)
├── latitude : number (double) (optional)
├── longitude : number (double) (optional)
```
```text
Nabd.Application.DTOs.Common.Address.UpdateAddressRequest
├── street : string (optional)
├── city : string (optional)
├── governorate : Nabd.Core.Enums.Governorate (optional)
├── buildingNumber : string (optional)
├── latitude : number (double) (optional)
├── longitude : number (double) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.API.Controllers.UnreadCountResponse, Nabd.API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.API.Controllers.UnreadCountResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Address.AddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Address.AddressResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]] (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorServicesResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.DoctorServicesResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDatesListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.ExceptionalDatesListResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicImageResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Clinic.ClinicImageResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicImagesListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Clinic.ClinicImagesListResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ClinicInfoResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Clinic.ClinicInfoResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDashboardStatsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorDashboardStatsResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDetailsWithClinicResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorDetailsWithClinicResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPersonalProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorPersonalProfileResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfessionalInfoResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorProfessionalInfoResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorSpecialtyExperienceResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.DoctorSpecialtyExperienceResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientMedicalRecordResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.PatientMedicalRecordResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionsListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionsListResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Doctor.PatientSessionDocumentationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Doctor.PatientSessionDocumentationListResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.MedicalRecordResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Patient.MedicalRecordResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Patient.PatientResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionDetailedResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Prescription.PrescriptionDetailedResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionQueryResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Prescription.PrescriptionQueryResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewDetailsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Review.DoctorReviewDetailsResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Review.DoctorReviewResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewStatisticsResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Review.DoctorReviewStatisticsResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.EndSessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Session.EndSessionResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[Nabd.Application.DTOs.Responses.Session.SessionResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Nabd.Application.DTOs.Responses.Session.SessionResponse (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.AvailableTimeSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.AvailableTimeSlotResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentSlotResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Doctor.SpecialtyResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.SpecialtyResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Notification.NotificationResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.CurrentMedicationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Prescription.CurrentMedicationResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.MedicationNameResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Prescription.MedicationNameResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.IEnumerable`1[[Nabd.Application.DTOs.Responses.Prescription.PrescriptionListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Prescription.PrescriptionListItemResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Appointment.DayScheduleSlotResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.DayScheduleSlotResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Collections.Generic.List`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentItemResponse> (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Base.ApiResponse`1[[System.Object, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
├── isSuccess : boolean (optional)
├── message : string (optional)
├── data : object (optional)
├── errors : Array<string> (optional)
├── statusCode : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Notification.NotificationResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Notification.NotificationResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Patient.PatientResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Patient.PatientResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Common.Pagination.PaginatedResponse`1[[Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse, Nabd.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
├── pageNumber : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── data : Array<Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse> (optional)
├── statistics : Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics (optional)
```
```text
Nabd.Application.DTOs.Requests.Appointment.AddExceptionalDateRequest
├── date : string (date-time) (required)
├── fromTime : string (optional)
├── toTime : string (optional)
├── fromPeriod : string (optional)
├── toPeriod : string (optional)
├── isClosed : boolean (required)
```
```text
Nabd.Application.DTOs.Requests.Appointment.BookAppointmentRequest
├── doctorId : string (uuid) (optional)
├── appointmentDate : string (optional)
├── appointmentTime : string (optional)
├── consultationType : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Requests.Appointment.CancelAppointmentRequest
├── cancellationReason : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Appointment.CreateAppointmentRequest
├── patientId : string (uuid) (required)
├── doctorId : string (uuid) (required)
├── scheduledStartTime : string (date-time) (required)
├── scheduledEndTime : string (date-time) (required)
├── consultationType : Nabd.Core.Enums.Appointments.ConsultationTypeEnum (required)
```
```text
Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto
├── enabled : boolean (optional)
├── fromTime : string (optional)
├── toTime : string (optional)
├── fromPeriod : string (optional)
├── toPeriod : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Appointment.RescheduleAppointmentRequest
├── newScheduledStartTime : string (date-time) (required)
├── newScheduledEndTime : string (date-time) (required)
```
```text
Nabd.Application.DTOs.Requests.Appointment.UpdateAppointmentRequest
├── scheduledStartTime : string (date-time) (optional)
├── scheduledEndTime : string (date-time) (optional)
├── consultationType : Nabd.Core.Enums.Appointments.ConsultationTypeEnum (optional)
├── status : Nabd.Core.Enums.Appointments.AppointmentStatus (optional)
├── cancellationReason : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Appointment.UpdateWeeklyScheduleRequest
├── weeklySchedule : Nabd.Application.DTOs.Requests.Appointment.WeeklyScheduleDto (required)
```
```text
Nabd.Application.DTOs.Requests.Appointment.WeeklyScheduleDto
├── saturday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── sunday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── monday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── tuesday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── wednesday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── thursday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
├── friday : Nabd.Application.DTOs.Requests.Appointment.DayScheduleDto (optional)
```
```text
Nabd.Application.DTOs.Requests.Auth.ChangePasswordRequest
├── currentPassword : string (required)
├── newPassword : string (required)
├── confirmNewPassword : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.DeleteAccountRequest
├── email : string (email) (required)
├── password : string (optional)
├── confirmationText : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.ForgotPasswordRequest
├── email : string (email) (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.GoogleLoginRequest
├── idToken : string (required)
├── userType : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Auth.LoginRequest
├── email : string (email) (required)
├── password : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.RefreshTokenRequest
├── accessToken : string (required)
├── refreshToken : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.RegisterDoctorRequest
├── firstName : string (required)
├── lastName : string (required)
├── email : string (email) (required)
├── password : string (required)
├── confirmPassword : string (required)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.RegisterPatientRequest
├── firstName : string (required)
├── lastName : string (required)
├── email : string (email) (required)
├── password : string (required)
├── confirmPassword : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.RegisterVerifierRequest
├── firstName : string (required)
├── lastName : string (required)
├── email : string (email) (required)
├── password : string (required)
├── confirmPassword : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.ResendOtpRequest
├── email : string (email) (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.VerifyEmailRequest
├── email : string (email) (required)
├── otpCode : string (required)
```
```text
Nabd.Application.DTOs.Requests.Auth.VerifyResetOtpRequest
├── email : string (email) (required)
├── otpCode : string (required)
├── newPassword : string (required)
├── confirmPassword : string (required)
```
```text
Nabd.Application.DTOs.Requests.Clinic.PhoneNumberDto
├── number : string (tel) (required)
├── type : integer (int32) (required)
```
```text
Nabd.Application.DTOs.Requests.Clinic.ServiceItemDto
├── id : integer (int32) (optional)
├── label : string (optional)
├── value : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Clinic.UpdateClinicAddressRequest
├── governorate : string (required)
├── city : string (required)
├── street : string (required)
├── buildingNumber : string (optional)
├── latitude : number (double) (optional)
├── longitude : number (double) (optional)
```
```text
Nabd.Application.DTOs.Requests.Clinic.UpdateClinicInfoRequest
├── clinicName : string (optional)
├── phoneNumbers : Array<Nabd.Application.DTOs.Requests.Clinic.PhoneNumberDto> (optional)
├── services : Array<Nabd.Application.DTOs.Requests.Clinic.ServiceItemDto> (optional)
```
```text
Nabd.Application.DTOs.Requests.Clinic.UpdateServicePricingRequest
├── price : number (double) (required)
├── duration : integer (int32) (required)
```
```text
Nabd.Application.DTOs.Requests.Diagnosis.DiagnosisRequestDto
├── patientId : string (required)
├── symptomsText : string (optional)
├── evidenceCodes : Array<string> (optional)
├── age : integer (int32) (optional)
├── sex : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Doctor.UpdateDoctorProfileRequest
├── firstName : string (optional)
├── lastName : string (optional)
├── phoneNumber : string (tel) (optional)
├── profileImage : string (binary) (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── dateOfBirth : string (date-time) (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── yearsOfExperience : integer (int32) (optional)
├── biography : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Doctor.UpdatePersonalInfoRequest
├── firstName : string (optional)
├── lastName : string (optional)
├── phoneNumber : string (tel) (optional)
├── dateOfBirth : string (date) (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── biography : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Doctor.UpdateSpecialtyExperienceRequest
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (required)
├── yearsOfExperience : integer (int32) (required)
```
```text
Nabd.Application.DTOs.Requests.Documentation.SaveDocumentationRequest
├── chiefComplaint : string (optional)
├── historyOfPresentIllness : string (optional)
├── physicalExamination : string (optional)
├── diagnosis : string (optional)
├── managementPlan : string (optional)
├── sessionType : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.ChronicDiseaseItemRequest
├── id : string (uuid) (optional)
├── diseaseName : string (required)
```
```text
Nabd.Application.DTOs.Requests.Patient.CreateMedicalHistoryItemRequest
├── type : Nabd.Core.Enums.MedicalHistoryType (required)
├── text : string (required)
```
```text
Nabd.Application.DTOs.Requests.Patient.CreatePatientRequest
├── firstName : string (required)
├── lastName : string (required)
├── email : string (email) (required)
```
```text
Nabd.Application.DTOs.Requests.Patient.CurrentMedicationItemRequest
├── id : string (uuid) (optional)
├── medicationName : string (required)
├── dosage : string (optional)
├── frequency : string (optional)
├── startDate : string (date-time) (optional)
├── reason : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.DrugAllergyItemRequest
├── id : string (uuid) (optional)
├── drugName : string (required)
├── reaction : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.PatientSortBy
```
```text
Nabd.Application.DTOs.Requests.Patient.PreviousSurgeryItemRequest
├── id : string (uuid) (optional)
├── surgeryName : string (required)
├── surgeryDate : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.UpdateMedicalHistoryItemRequest
├── type : Nabd.Core.Enums.MedicalHistoryType (optional)
├── text : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.UpdateMedicalRecordRequest
├── drugAllergies : Array<Nabd.Application.DTOs.Requests.Patient.DrugAllergyItemRequest> (optional)
├── chronicDiseases : Array<Nabd.Application.DTOs.Requests.Patient.ChronicDiseaseItemRequest> (optional)
├── currentMedications : Array<Nabd.Application.DTOs.Requests.Patient.CurrentMedicationItemRequest> (optional)
├── previousSurgeries : Array<Nabd.Application.DTOs.Requests.Patient.PreviousSurgeryItemRequest> (optional)
```
```text
Nabd.Application.DTOs.Requests.Patient.UpdatePatientRequest
├── firstName : string (optional)
├── lastName : string (optional)
├── phoneNumber : string (tel) (optional)
├── birthDate : string (date-time) (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
```
```text
Nabd.Application.DTOs.Requests.Payment.InitiateAppointmentPaymentRequest
├── paymentMethod : Nabd.Core.Enums.Payment.PaymentMethod (required)
├── paymentType : Nabd.Core.Enums.Payment.PaymentType (optional)
```
```text
Nabd.Application.DTOs.Requests.Prescription.CancelPrescriptionRequest
├── reason : string (required)
├── notes : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Prescription.CreatePrescribedMedicationRequest
├── medicationId : string (uuid) (required)
├── dosage : string (required)
├── frequency : string (required)
├── durationDays : integer (int32) (required)
├── specialInstructions : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Prescription.CreatePrescriptionRequest
├── appointmentId : string (uuid) (required)
├── doctorId : string (uuid) (required)
├── patientId : string (uuid) (required)
├── prescriptionNumber : string (required)
├── digitalSignature : string (required)
├── generalInstructions : string (optional)
├── prescribedMedications : Array<Nabd.Application.DTOs.Requests.Prescription.CreatePrescribedMedicationRequest> (required)
```
```text
Nabd.Application.DTOs.Requests.Prescription.RenewPrescriptionRequest
├── generalInstructions : string (optional)
├── durationInDays : integer (int32) (optional)
├── renewalReason : string (optional)
├── copyAllMedications : boolean (optional)
├── newAppointmentId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Requests.Prescription.UpdatePrescriptionRequest
├── generalInstructions : string (optional)
```
```text
Nabd.Application.DTOs.Requests.Review.CreateDoctorReviewRequest
├── appointmentId : string (uuid) (required)
├── overallSatisfaction : integer (int32) (required)
├── waitingTime : integer (int32) (required)
├── communicationQuality : integer (int32) (required)
├── clinicCleanliness : integer (int32) (required)
├── valueForMoney : integer (int32) (required)
├── comment : string (optional)
├── isAnonymous : boolean (optional)
```
```text
Nabd.Application.DTOs.Requests.Review.ReplyToReviewRequest
├── reply : string (required)
```
```text
Nabd.Application.DTOs.Requests.Verifier.RejectDocumentRequest
├── rejectionReason : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.AppointmentResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── doctorId : string (uuid) (optional)
├── previousAppointmentId : string (uuid) (optional)
├── scheduledStartTime : string (date-time) (optional)
├── scheduledEndTime : string (date-time) (optional)
├── consultationType : Nabd.Core.Enums.Appointments.ConsultationTypeEnum (optional)
├── consultationFee : number (double) (optional)
├── sessionDurationMinutes : integer (int32) (optional)
├── status : Nabd.Core.Enums.Appointments.AppointmentStatus (optional)
├── cancellationReason : string (optional)
├── cancelledAt : string (date-time) (optional)
├── actualStartTime : string (date-time) (optional)
├── actualEndTime : string (date-time) (optional)
├── patientName : string (optional)
├── patientAge : integer (int32) (optional)
├── patientProfileImageUrl : string (optional)
├── prescriptionId : string (uuid) (optional)
├── patient : Nabd.Application.DTOs.Responses.Patient.PatientBasicResponse (optional)
├── doctor : Nabd.Application.DTOs.Responses.Doctor.DoctorBasicResponse (optional)
├── consultationRecord : Nabd.Application.DTOs.Responses.Appointment.ConsultationRecordResponse (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.AppointmentStatistics
├── total : integer (int32) (optional)
├── pending : integer (int32) (optional)
├── confirmed : integer (int32) (optional)
├── checkedIn : integer (int32) (optional)
├── inProgress : integer (int32) (optional)
├── completed : integer (int32) (optional)
├── noShow : integer (int32) (optional)
├── cancelled : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.AvailableTimeSlotResponse
├── time : string (optional)
├── isAvailable : boolean (optional)
├── isBooked : boolean (optional)
├── isPast : boolean (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentResponse
├── id : string (uuid) (optional)
├── doctorId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── appointmentDate : string (optional)
├── appointmentTime : string (optional)
├── consultationType : integer (int32) (optional)
├── status : string (optional)
├── totalAmount : number (double) (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.BookedAppointmentSlotResponse
├── appointmentId : string (uuid) (optional)
├── time : string (optional)
├── patientName : string (optional)
├── consultationType : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.ConsultationRecordResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── appointmentId : string (uuid) (optional)
├── chiefComplaint : string (optional)
├── historyOfPresentIllness : string (optional)
├── physicalExamination : string (optional)
├── diagnosis : string (optional)
├── managementPlan : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto
├── enabled : boolean (optional)
├── fromTime : string (optional)
├── toTime : string (optional)
├── fromPeriod : string (optional)
├── toPeriod : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.DayScheduleSlotResponse
├── dayOfWeek : integer (int32) (optional)
├── isEnabled : boolean (optional)
├── fromTime : string (optional)
├── toTime : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.DoctorAppointmentResponse
├── id : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── patientName : string (optional)
├── patientPhoneNumber : string (optional)
├── appointmentDate : string (optional)
├── appointmentTime : string (optional)
├── duration : integer (int32) (optional)
├── appointmentType : string (optional)
├── status : Nabd.Core.Enums.Appointments.AppointmentStatus (optional)
├── createdAt : string (date-time) (optional)
├── notes : string (optional)
├── price : number (double) (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.DoctorServicesResponse
├── regularCheckup : Nabd.Application.DTOs.Responses.Appointment.ServiceDetailsResponse (optional)
├── reExamination : Nabd.Application.DTOs.Responses.Appointment.ServiceDetailsResponse (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse
├── id : string (uuid) (optional)
├── date : string (optional)
├── fromTime : string (optional)
├── toTime : string (optional)
├── fromPeriod : string (optional)
├── toPeriod : string (optional)
├── isClosed : boolean (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.ExceptionalDatesListResponse
├── exceptionalDates : Array<Nabd.Application.DTOs.Responses.Appointment.ExceptionalDateResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.ServiceDetailsResponse
├── price : number (double) (optional)
├── duration : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleDataDto
├── saturday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── sunday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── monday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── tuesday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── wednesday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── thursday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
├── friday : Nabd.Application.DTOs.Responses.Appointment.DayScheduleResponseDto (optional)
```
```text
Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleResponse
├── weeklySchedule : Nabd.Application.DTOs.Responses.Appointment.WeeklyScheduleDataDto (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse
├── governorate : string (optional)
├── city : string (optional)
├── street : string (optional)
├── buildingNumber : string (optional)
├── latitude : number (double) (optional)
├── longitude : number (double) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicImageResponse
├── id : string (uuid) (optional)
├── url : string (optional)
├── order : integer (int32) (optional)
├── uploadedAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicImagesListResponse
├── images : Array<Nabd.Application.DTOs.Responses.Clinic.ClinicImageResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicInfoResponse
├── clinicName : string (optional)
├── phoneNumbers : Array<Nabd.Application.DTOs.Responses.Clinic.PhoneNumberResponse> (optional)
├── services : Array<Nabd.Application.DTOs.Responses.Clinic.ServiceItemResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicPhoneNumberResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── number : string (optional)
├── type : string (optional)
├── clinicId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicPhotoResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── photoUrl : string (optional)
├── caption : string (optional)
├── clinicId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ClinicServiceResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── serviceName : string (optional)
├── description : string (optional)
├── clinicId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.PhoneNumberResponse
├── number : string (optional)
├── type : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ServiceItemResponse
├── id : integer (int32) (optional)
├── label : string (optional)
├── value : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Clinic.ServicePricingResponse
├── price : number (double) (optional)
├── duration : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Diagnosis.AiDiagnosisResultDto
├── disease : string (optional)
├── confidence : number (double) (optional)
├── nameAr : string (optional)
├── descriptionAr : string (optional)
├── precautionsAr : Array<string> (optional)
```
```text
Nabd.Application.DTOs.Responses.Diagnosis.DiagnosisResponseDto
├── patientId : string (optional)
├── originalSymptoms : string (optional)
├── normalizedSymptoms : Array<string> (optional)
├── suggestedDiagnosis : string (optional)
├── topResults : Array<Nabd.Application.DTOs.Responses.Diagnosis.AiDiagnosisResultDto> (optional)
├── confidenceLevel : integer (int32) (optional)
├── generatedAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.ClinicDetailsResponse
├── id : string (uuid) (optional)
├── name : string (optional)
├── phoneNumbers : Array<Nabd.Application.DTOs.Responses.Clinic.ClinicPhoneNumberResponse> (optional)
├── offeredServices : Array<Nabd.Application.DTOs.Responses.Clinic.ClinicServiceResponse> (optional)
├── address : Nabd.Application.DTOs.Responses.Clinic.ClinicAddressResponse (optional)
├── photos : Array<Nabd.Application.DTOs.Responses.Clinic.ClinicPhotoResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorBasicResponse
├── id : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── profileImageUrl : string (optional)
├── averageRating : number (double) (optional)
├── yearsOfExperience : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorDashboardStatsResponse
├── totalPatients : integer (int32) (optional)
├── todayAppointments : integer (int32) (optional)
├── completedAppointments : integer (int32) (optional)
├── totalRevenue : number (double) (optional)
├── monthlyRevenue : number (double) (optional)
├── pendingAppointments : integer (int32) (optional)
├── cancelledAppointments : integer (int32) (optional)
├── averageRating : number (double) (optional)
├── totalReviews : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorDetailsWithClinicResponse
├── id : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── medicalSpecialtyName : string (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── genderName : string (optional)
├── dateOfBirth : string (date-time) (optional)
├── profileImageUrl : string (optional)
├── biography : string (optional)
├── yearsOfExperience : integer (int32) (optional)
├── clinic : Nabd.Application.DTOs.Responses.Doctor.ClinicDetailsResponse (optional)
├── partnerSuggestions : Nabd.Application.DTOs.Responses.Doctor.PartnerSuggestionsResponse (optional)
├── averageRating : number (double) (optional)
├── totalReviews : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentItemResponse
├── id : string (uuid) (optional)
├── documentUrl : string (optional)
├── type : Nabd.Core.Enums.Doctor.DoctorDocumentType (optional)
├── typeName : string (optional)
├── status : Nabd.Core.Enums.VerificationDocumentStatus (optional)
├── statusName : string (optional)
├── rejectionReason : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── documentUrl : string (optional)
├── type : Nabd.Core.Enums.Doctor.DoctorDocumentType (optional)
├── typeName : string (optional)
├── status : Nabd.Core.Enums.VerificationDocumentStatus (optional)
├── statusName : string (optional)
├── rejectionReason : string (optional)
├── doctorId : string (uuid) (optional)
├── doctorName : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorListItemResponse
├── id : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── medicalSpecialtyName : string (optional)
├── governorate : string (optional)
├── city : string (optional)
├── longitude : number (double) (optional)
├── latitude : number (double) (optional)
├── nextAvailableSlot : string (date-time) (optional)
├── averageRating : number (double) (optional)
├── regularConsultationFee : number (double) (optional)
├── profileImageUrl : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorPatientResponse
├── id : string (uuid) (optional)
├── fullName : string (optional)
├── phoneNumber : string (optional)
├── profileImageUrl : string (optional)
├── totalSessions : integer (int32) (optional)
├── lastVisitDate : string (date-time) (optional)
├── address : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorPersonalProfileResponse
├── id : string (uuid) (optional)
├── profilePictureUrl : string (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── email : string (optional)
├── phoneNumber : string (optional)
├── dateOfBirth : string (date-time) (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── genderName : string (optional)
├── biography : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorProfessionalInfoResponse
├── doctorId : string (uuid) (optional)
├── doctorName : string (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── specialtyName : string (optional)
├── yearsOfExperience : integer (int32) (optional)
├── documents : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentResponse> (optional)
├── totalDocuments : integer (int32) (optional)
├── approvedDocuments : integer (int32) (optional)
├── pendingDocuments : integer (int32) (optional)
├── rejectedDocuments : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorProfileResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── email : string (optional)
├── phoneNumber : string (optional)
├── profilePictureUrl : string (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── genderName : string (optional)
├── dateOfBirth : string (date-time) (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── medicalSpecialtyName : string (optional)
├── biography : string (optional)
├── verificationStatus : Nabd.Core.Enums.Identity.VerificationStatus (optional)
├── verificationStatusName : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorSpecialtyExperienceResponse
├── doctorId : string (uuid) (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── specialtyName : string (optional)
├── yearsOfExperience : integer (int32) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.DoctorVerificationListResponse
├── id : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── medicalSpecialty : Nabd.Core.Enums.Doctor.MedicalSpecialty (optional)
├── medicalSpecialtyName : string (optional)
├── governorate : string (optional)
├── city : string (optional)
├── profileImageUrl : string (optional)
├── yearsOfExperience : integer (int32) (optional)
├── phoneNumber : string (optional)
├── email : string (optional)
├── verificationStatus : Nabd.Core.Enums.Identity.VerificationStatus (optional)
├── verificationStatusName : string (optional)
├── documents : Array<Nabd.Application.DTOs.Responses.Doctor.DoctorDocumentItemResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.MedicalHistoryItemResponse
├── id : string (uuid) (optional)
├── type : Nabd.Core.Enums.MedicalHistoryType (optional)
├── typeName : string (optional)
├── text : string (optional)
├── createdAt : string (date-time) (optional)
├── updatedAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PartnerBasicInfoResponse
├── id : string (uuid) (optional)
├── name : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PartnerSuggestionsResponse
├── suggestedPharmacy : Nabd.Application.DTOs.Responses.Doctor.PartnerBasicInfoResponse (optional)
├── suggestedLaboratory : Nabd.Application.DTOs.Responses.Doctor.PartnerBasicInfoResponse (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PatientMedicalRecordResponse
├── patientId : string (uuid) (optional)
├── patientFullName : string (optional)
├── medicalHistory : Array<Nabd.Application.DTOs.Responses.Doctor.MedicalHistoryItemResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionMedicationResponse
├── medicationName : string (optional)
├── dosage : string (optional)
├── frequency : string (optional)
├── durationDays : integer (int32) (optional)
├── specialInstructions : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionResponse
├── prescriptionId : string (uuid) (optional)
├── patientFullName : string (optional)
├── prescriptionNumber : string (optional)
├── prescriptionDate : string (date-time) (optional)
├── appointmentId : string (uuid) (optional)
├── medications : Array<Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionMedicationResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionsListResponse
├── patientId : string (uuid) (optional)
├── patientFullName : string (optional)
├── totalPrescriptions : integer (int32) (optional)
├── prescriptions : Array<Nabd.Application.DTOs.Responses.Doctor.PatientPrescriptionResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.PatientSessionDocumentationListResponse
├── patientId : string (uuid) (optional)
├── patientFullName : string (optional)
├── totalSessions : integer (int32) (optional)
├── sessions : Array<Nabd.Application.DTOs.Responses.Doctor.SessionDocumentationResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.SessionDocumentationResponse
├── appointmentId : string (uuid) (optional)
├── consultationRecordId : string (uuid) (optional)
├── sessionDate : string (date-time) (optional)
├── sessionTime : string (date-span) (optional)
├── sessionType : Nabd.Core.Enums.Appointments.ConsultationTypeEnum (optional)
├── sessionTypeName : string (optional)
├── sessionDurationMinutes : integer (int32) (optional)
├── chiefComplaint : string (optional)
├── historyOfPresentIllness : string (optional)
├── physicalExamination : string (optional)
├── diagnosis : string (optional)
├── managementPlan : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.SpecialtyResponse
├── id : integer (int32) (optional)
├── name : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Doctor.TodayAppointmentResponse
├── id : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── patientName : string (optional)
├── patientPhoneNumber : string (optional)
├── appointmentTime : string (optional)
├── appointmentDate : string (optional)
├── duration : integer (int32) (optional)
├── appointmentType : string (optional)
├── status : string (optional)
├── notes : string (optional)
├── price : number (double) (optional)
```
```text
Nabd.Application.DTOs.Responses.Documentation.DocumentationResponse
├── consultationRecordId : string (uuid) (optional)
├── chiefComplaint : string (optional)
├── historyOfPresentIllness : string (optional)
├── physicalExamination : string (optional)
├── diagnosis : string (optional)
├── managementPlan : string (optional)
├── sessionType : integer (int32) (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Notification.NotificationResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── userId : string (uuid) (optional)
├── type : Nabd.Core.Enums.Notifications.NotificationType (optional)
├── title : string (optional)
├── message : string (optional)
├── relatedEntityType : string (optional)
├── relatedEntityId : string (uuid) (optional)
├── isRead : boolean (optional)
├── readAt : string (date-time) (optional)
├── priority : Nabd.Core.Enums.Notifications.NotificationPriority (optional)
├── deliveryMethod : Nabd.Core.Enums.Notifications.NotificationDeliveryMethod (optional)
├── isSent : boolean (optional)
├── sentAt : string (date-time) (optional)
├── failureReason : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.ChronicDiseaseItem
├── id : string (uuid) (optional)
├── diseaseName : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.CurrentMedicationItem
├── id : string (uuid) (optional)
├── medicationName : string (optional)
├── dosage : string (optional)
├── frequency : string (optional)
├── startDate : string (date-time) (optional)
├── reason : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.DrugAllergyItem
├── id : string (uuid) (optional)
├── drugName : string (optional)
├── reaction : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.MedicalHistoryItemResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── type : Nabd.Core.Enums.MedicalHistoryType (optional)
├── text : string (optional)
├── patientId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.MedicalRecordResponse
├── patientId : string (uuid) (optional)
├── patientFullName : string (optional)
├── lastUpdatedAt : string (date-time) (optional)
├── drugAllergies : Array<Nabd.Application.DTOs.Responses.Patient.DrugAllergyItem> (optional)
├── chronicDiseases : Array<Nabd.Application.DTOs.Responses.Patient.ChronicDiseaseItem> (optional)
├── currentMedications : Array<Nabd.Application.DTOs.Responses.Patient.CurrentMedicationItem> (optional)
├── previousSurgeries : Array<Nabd.Application.DTOs.Responses.Patient.PreviousSurgeryItem> (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.PatientBasicResponse
├── id : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── phoneNumber : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.PatientResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── firstName : string (optional)
├── lastName : string (optional)
├── fullName : string (optional)
├── email : string (optional)
├── phoneNumber : string (optional)
├── birthDate : string (date-time) (optional)
├── gender : Nabd.Core.Enums.Identity.Gender (optional)
├── profileImageUrl : string (optional)
├── address : Nabd.Application.DTOs.Common.Address.AddressResponse (optional)
├── medicalHistory : Array<Nabd.Application.DTOs.Responses.Patient.MedicalHistoryItemResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Patient.PreviousSurgeryItem
├── id : string (uuid) (optional)
├── surgeryName : string (optional)
├── surgeryDate : string (date-time) (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.CurrentMedicationResponse
├── medicationId : string (uuid) (optional)
├── brandName : string (optional)
├── genericName : string (optional)
├── strength : string (optional)
├── dosageForm : string (optional)
├── prescriptionId : string (uuid) (optional)
├── prescriptionNumber : string (optional)
├── prescribedDate : string (date-time) (optional)
├── dosage : string (optional)
├── frequency : string (optional)
├── durationInDays : integer (int32) (optional)
├── specialInstructions : string (optional)
├── doctorId : string (uuid) (optional)
├── doctorName : string (optional)
├── doctorSpecialization : string (optional)
├── isDispensed : boolean (optional)
├── dispensedDate : string (date-time) (optional)
├── remainingDays : integer (int32) (optional)
├── startDate : string (date-time) (optional)
├── endDate : string (date-time) (optional)
├── daysRemaining : integer (int32) (optional)
├── medicationName : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.MedicationDetailResponse
├── medicationName : string (optional)
├── dosage : string (optional)
├── frequency : string (optional)
├── durationDays : integer (int32) (optional)
├── specialInstructions : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.MedicationNameResponse
├── id : string (uuid) (optional)
├── brandName : string (optional)
├── genericName : string (optional)
├── strength : string (optional)
├── dosageForm : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.MedicationResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── brandName : string (optional)
├── genericName : string (optional)
├── strength : string (optional)
├── dosageForm : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PatientPrescriptionListResponse
├── id : string (uuid) (optional)
├── prescriptionNumber : string (optional)
├── createdAt : string (date-time) (optional)
├── status : integer (int32) (optional)
├── statusName : string (optional)
├── doctorId : string (uuid) (optional)
├── doctorName : string (optional)
├── doctorSpecialty : string (optional)
├── doctorProfileImageUrl : string (optional)
├── appointmentType : string (optional)
├── appointmentId : string (uuid) (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PrescribedMedicationResponse
├── dosage : string (optional)
├── frequency : string (optional)
├── durationDays : integer (int32) (optional)
├── specialInstructions : string (optional)
├── medicationId : string (uuid) (optional)
├── medication : Nabd.Application.DTOs.Responses.Prescription.MedicationResponse (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PrescriptionDetailedResponse
├── id : string (uuid) (optional)
├── prescriptionNumber : string (optional)
├── createdAt : string (date-time) (optional)
├── medications : Array<Nabd.Application.DTOs.Responses.Prescription.MedicationDetailResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PrescriptionListItemResponse
├── id : string (uuid) (optional)
├── prescriptionNumber : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PrescriptionQueryResponse
├── prescriptions : Array<Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse> (optional)
├── page : integer (int32) (optional)
├── pageSize : integer (int32) (optional)
├── totalCount : integer (int32) (optional)
├── totalPages : integer (int32) (optional)
├── hasPreviousPage : boolean (optional)
├── hasNextPage : boolean (optional)
├── appliedFilters : object (optional)
```
```text
Nabd.Application.DTOs.Responses.Prescription.PrescriptionResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── prescriptionNumber : string (optional)
├── digitalSignature : string (optional)
├── appointmentId : string (uuid) (optional)
├── doctorId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── generalInstructions : string (optional)
├── status : Nabd.Core.Enums.PrescriptionStatus (optional)
├── dispensedAt : string (date-time) (optional)
├── cancellationReason : string (optional)
├── cancelledAt : string (date-time) (optional)
├── doctor : Nabd.Application.DTOs.Responses.Doctor.DoctorBasicResponse (optional)
├── patient : Nabd.Application.DTOs.Responses.Patient.PatientBasicResponse (optional)
├── prescribedMedications : Array<Nabd.Application.DTOs.Responses.Prescription.PrescribedMedicationResponse> (optional)
```
```text
Nabd.Application.DTOs.Responses.Review.DoctorReviewDetailsResponse
├── reviewId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── patientName : string (optional)
├── patientProfileImage : string (optional)
├── overallSatisfaction : integer (int32) (optional)
├── waitingTime : integer (int32) (optional)
├── communicationQuality : integer (int32) (optional)
├── clinicCleanliness : integer (int32) (optional)
├── valueForMoney : integer (int32) (optional)
├── averageRating : number (double) (optional)
├── comment : string (optional)
├── hasDoctorReply : boolean (optional)
├── doctorReply : string (optional)
├── doctorRepliedAt : string (date-time) (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Review.DoctorReviewListItemResponse
├── reviewId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── patientName : string (optional)
├── patientProfileImage : string (optional)
├── rating : integer (int32) (optional)
├── comment : string (optional)
├── createdAt : string (date-time) (optional)
```
```text
Nabd.Application.DTOs.Responses.Review.DoctorReviewResponse
├── id : string (uuid) (optional)
├── createdAt : string (date-time) (optional)
├── createdBy : string (uuid) (optional)
├── updatedAt : string (date-time) (optional)
├── updatedBy : string (uuid) (optional)
├── appointmentId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── doctorId : string (uuid) (optional)
├── overallSatisfaction : integer (int32) (optional)
├── waitingTime : integer (int32) (optional)
├── communicationQuality : integer (int32) (optional)
├── clinicCleanliness : integer (int32) (optional)
├── valueForMoney : integer (int32) (optional)
├── comment : string (optional)
├── isAnonymous : boolean (optional)
├── isEdited : boolean (optional)
├── doctorReply : string (optional)
├── doctorRepliedAt : string (date-time) (optional)
├── averageRating : number (double) (optional)
```
```text
Nabd.Application.DTOs.Responses.Review.DoctorReviewStatisticsResponse
├── averageRating : number (double) (optional)
├── totalReviews : integer (int32) (optional)
├── ratingDistribution : object (optional)
```
```text
Nabd.Application.DTOs.Responses.Session.EndSessionResponse
├── sessionId : string (uuid) (optional)
├── endTime : string (date-time) (optional)
├── status : string (optional)
```
```text
Nabd.Application.DTOs.Responses.Session.SessionResponse
├── sessionId : string (uuid) (optional)
├── appointmentId : string (uuid) (optional)
├── patientId : string (uuid) (optional)
├── patientName : string (optional)
├── patientPhone : string (optional)
├── patientAge : integer (int32) (optional)
├── patientProfileImageUrl : string (optional)
├── startTime : string (date-time) (optional)
├── endTime : string (date-time) (optional)
├── duration : integer (int32) (optional)
├── sessionType : integer (int32) (optional)
├── status : string (optional)
├── scheduledStartTime : string (date-time) (optional)
├── scheduledEndTime : string (date-time) (optional)
```
```text
Nabd.Core.Enums.Appointments.AppointmentStatus
```
```text
Nabd.Core.Enums.Appointments.ConsultationTypeEnum
```
```text
Nabd.Core.Enums.Doctor.DoctorDocumentType
```
```text
Nabd.Core.Enums.Doctor.MedicalSpecialty
```
```text
Nabd.Core.Enums.Governorate
```
```text
Nabd.Core.Enums.Identity.Gender
```
```text
Nabd.Core.Enums.Identity.VerificationStatus
```
```text
Nabd.Core.Enums.MedicalHistoryType
```
```text
Nabd.Core.Enums.Notifications.NotificationDeliveryMethod
```
```text
Nabd.Core.Enums.Notifications.NotificationPriority
```
```text
Nabd.Core.Enums.Notifications.NotificationType
```
```text
Nabd.Core.Enums.Payment.PaymentMethod
```
```text
Nabd.Core.Enums.Payment.PaymentType
```
```text
Nabd.Core.Enums.PrescriptionStatus
```
```text
Nabd.Core.Enums.VerificationDocumentStatus
```
## Error Responses
The API uses standard HTTP status codes and a uniform error response format for 400 Validation Errors.
```json
{
  "message": "Validation Failed",
  "errors": {
    "email": [
      "Email is required"
    ]
  }
}
```
- **400 Bad Request:** Validation errors.
- **401 Unauthorized:** Missing or invalid JWT.
- **403 Forbidden:** Valid JWT but missing required role.
- **404 Not Found:** Resource does not exist.
- **409 Conflict:** Resource already exists.
- **422 Unprocessable Entity:** Business logic error.
- **500 Internal Server Error:** Server crash.
## Pagination
Endpoints that return lists usually support pagination via query parameters:
- `pageNumber`: The page number (default 1).
- `pageSize`: Number of items per page (default 10).
## File Upload Endpoints
Endpoints requiring file uploads (e.g., Profile Picture, Documents) accept `multipart/form-data`.
- Standard fields typically include `file` or `image`.
- Maximum file size depends on the server limit (often 5-10MB).
## Feature Coverage Matrix
| Feature | Backend Ready | Mobile Connected |
|---|---|---|
| Appointments | Yes | Unknown |
| Auth | Yes | Unknown |
| Clinics | Yes | Unknown |
| Debug | Yes | Unknown |
| Diagnosis | Yes | Unknown |
| DoctorDashboard | Yes | Unknown |
| DoctorDocuments | Yes | Unknown |
| DoctorPatients | Yes | Unknown |
| DoctorReviews | Yes | Unknown |
| Doctors | Yes | Unknown |
| DoctorSchedule | Yes | Unknown |
| DoctorServices | Yes | Unknown |
| DoctorSessions | Yes | Unknown |
| Notifications | Yes | Unknown |
| PatientAppointments | Yes | Unknown |
| PatientMedical | Yes | Unknown |
| PatientProfile | Yes | Unknown |
| PatientReviews | Yes | Unknown |
| Patients | Yes | Unknown |
| Payments | Yes | Unknown |
| Prescriptions | Yes | Unknown |
| Seed | Yes | Unknown |
| Verifier | Yes | Unknown |
## Endpoint Checklist
```text
□ [POST] /api/Appointments/book
□ [GET] /api/Appointments/{appointmentId}
□ [POST] /api/Appointments/{appointmentId}/start-session
□ [GET] /api/Appointments/{appointmentId}/session
□ [POST] /api/Appointments/{appointmentId}/end-session
□ [POST] /api/Appointments/{appointmentId}/documentation
□ [PUT] /api/Appointments/{appointmentId}/documentation
□ [GET] /api/Appointments/{appointmentId}/documentation
□ [POST] /api/Appointments/{appointmentId}/prescription
□ [GET] /api/Appointments/{appointmentId}/prescription
□ [POST] /api/Auth/register/patient
□ [POST] /api/Auth/register/doctor
□ [POST] /api/Auth/register/verifier
□ [POST] /api/Auth/verify-email
□ [POST] /api/Auth/resend-verification
□ [POST] /api/Auth/login
□ [POST] /api/Auth/google
□ [POST] /api/Auth/forgot-password
□ [POST] /api/Auth/reset-password
□ [POST] /api/Auth/change-password
□ [POST] /api/Auth/refresh-token
□ [POST] /api/Auth/logout
□ [DELETE] /api/Auth/debug/delete-account-by-email
□ [DELETE] /api/Auth/delete-account
□ [GET] /api/Doctors/me/clinic/info
□ [PUT] /api/Doctors/me/clinic/info
□ [GET] /api/Doctors/me/clinic/address
□ [PUT] /api/Doctors/me/clinic/address
□ [GET] /api/Doctors/me/clinic/images
□ [POST] /api/Doctors/me/clinic/images
□ [DELETE] /api/Doctors/me/clinic/images/{imageId}
□ [GET] /api/debug/fix-verifier
□ [POST] /api/doctor/Diagnosis
□ [GET] /api/doctor/Diagnosis/health
□ [GET] /api/doctors/me/dashboard/stats
□ [GET] /api/doctors/me/dashboard/appointments
□ [GET] /api/doctors/me/dashboard/appointments/today
□ [GET] /api/doctors/me/documents/{documentId}
□ [GET] /api/doctors/me/documents/required
□ [POST] /api/doctors/me/documents/required
□ [GET] /api/doctors/me/documents/research
□ [POST] /api/doctors/me/documents/research
□ [GET] /api/doctors/me/documents/awards
□ [POST] /api/doctors/me/documents/awards
□ [GET] /api/doctors/me/patients
□ [GET] /api/doctors/me/patients/{patientId}/medical-record
□ [GET] /api/doctors/me/patients/{patientId}/session-documentations
□ [GET] /api/doctors/me/patients/{patientId}/prescriptions
□ [GET] /api/Doctors/me/reviews
□ [GET] /api/Doctors/me/reviews/statistics
□ [GET] /api/Doctors/me/reviews/{id}/details
□ [POST] /api/Doctors/me/reviews/{reviewId}/reply
□ [GET] /api/Doctors/me
□ [GET] /api/Doctors/{id}
□ [PUT] /api/Doctors/{id}
□ [GET] /api/Doctors/profile/personal
□ [PUT] /api/Doctors/profile/personal
□ [GET] /api/Doctors/profile/professional
□ [GET] /api/Doctors/profile/specialty-experience
□ [PUT] /api/Doctors/profile/specialty-experience
□ [PUT] /api/Doctors/me/profile-image
□ [GET] /api/Doctors/list
□ [GET] /api/Doctors/{doctorId}/details
□ [POST] /api/Doctors/me/submit-for-review
□ [GET] /api/Doctors/specialty/all
□ [GET] /api/doctors/{doctorId}/appointments/schedule
□ [GET] /api/doctors/{doctorId}/appointments/exceptions
□ [GET] /api/doctors/{doctorId}/services
□ [GET] /api/doctors/{doctorId}/appointments/booked
□ [GET] /api/doctors/{doctorId}/appointments/available-slots
□ [GET] /api/Doctors/me/services/regular-checkup
□ [PUT] /api/Doctors/me/services/regular-checkup
□ [GET] /api/Doctors/me/services/re-examination
□ [PUT] /api/Doctors/me/services/re-examination
□ [GET] /api/Doctors/me/appointments/schedule
□ [PUT] /api/Doctors/me/appointments/schedule
□ [GET] /api/Doctors/me/appointments/exceptions
□ [POST] /api/Doctors/me/appointments/exceptions
□ [DELETE] /api/Doctors/me/appointments/exceptions/{exceptionId}
□ [GET] /api/doctors/me/sessions/active
□ [GET] /api/Notifications/unread
□ [GET] /api/Notifications
□ [GET] /api/Notifications/unread-count
□ [PUT] /api/Notifications/{notificationId}/mark-as-read
□ [PUT] /api/Notifications/mark-all-as-read
□ [DELETE] /api/Notifications/{notificationId}
□ [POST] /api/Notifications/debug/test-send
□ [GET] /api/patients/me/appointments
□ [POST] /api/patients/me/appointments
□ [GET] /api/patients/me/appointments/{appointmentId}
□ [PUT] /api/patients/me/appointments/{appointmentId}
□ [DELETE] /api/patients/me/appointments/{appointmentId}
□ [GET] /api/patients/me/appointments/upcoming
□ [GET] /api/patients/me/appointments/past
□ [GET] /api/patients/me/appointments/status/{status}
□ [GET] /api/patients/me/appointments/date-range
□ [GET] /api/patients/me/appointments/count
□ [GET] /api/patients/me/appointments/check-availability
□ [PATCH] /api/patients/me/appointments/{appointmentId}/cancel
□ [PATCH] /api/patients/me/appointments/{appointmentId}/reschedule
□ [GET] /api/Patients/me/medical-history
□ [POST] /api/Patients/me/medical-history
□ [PUT] /api/Patients/me/medical-history/{itemId}
□ [DELETE] /api/Patients/me/medical-history/{itemId}
□ [GET] /api/Patients/me/prescriptions
□ [GET] /api/Patients/me/prescriptions/active
□ [GET] /api/Patients/me/prescriptions/{prescriptionId}
□ [GET] /api/Patients/me/prescriptions/list
□ [GET] /api/Patients/me/profile
□ [PUT] /api/Patients/me/profile
□ [GET] /api/Patients/me/address
□ [PUT] /api/Patients/me/address
□ [GET] /api/Patients/me/medical-record
□ [PUT] /api/Patients/me/medical-record
□ [PUT] /api/Patients/me/profile-image
□ [DELETE] /api/Patients/me/profile-image
□ [POST] /api/patients/me/reviews
□ [GET] /api/patients/me/reviews/doctors/{doctorId}/reviews
□ [GET] /api/patients/me/reviews/doctors/{doctorId}/reviews/statistics
□ [GET] /api/Patients/test
□ [POST] /api/Patients
□ [GET] /api/Patients
□ [DELETE] /api/Patients/{id}
□ [POST] /api/Patients/{id}/restore
□ [GET] /api/Patients/email/{email}
□ [GET] /api/Patients/paginated
□ [GET] /api/Patients/search
□ [GET] /api/Patients/with-medical-history
□ [GET] /api/Patients/check-email/{email}
□ [GET] /api/Patients/count
□ [GET] /api/Patients/current/{userId}
□ [POST] /api/Payments/appointments/{appointmentId}/initiate
□ [POST] /api/Payments/webhook/paymob
□ [GET] /api/Payments/{paymentId}
□ [POST] /api/Payments/{paymentId}/cancel
□ [POST] /api/Payments/{paymentId}/test-success
□ [GET] /api/Prescriptions
□ [POST] /api/Prescriptions
□ [GET] /api/Prescriptions/{id}
□ [PUT] /api/Prescriptions/{id}
□ [DELETE] /api/Prescriptions/{id}
□ [GET] /api/Prescriptions/number/{prescriptionNumber}
□ [POST] /api/Prescriptions/{id}/cancel
□ [POST] /api/Prescriptions/{id}/renew
□ [GET] /api/Prescriptions/patient/{patientId}/current-medications
□ [GET] /api/Prescriptions/patient/{patientId}/doctor/{doctorId}/prescription/{prescriptionId}
□ [GET] /api/Prescriptions/patient/{patientId}/doctor/{doctorId}/list
□ [GET] /api/Prescriptions/medications
□ [POST] /api/Seed/seed
□ [POST] /api/Seed/clear
□ [POST] /api/Verifier/doctors/{doctorId}/start-review
□ [POST] /api/Verifier/doctors/{doctorId}/verify
□ [POST] /api/Verifier/doctors/{doctorId}/reject
□ [GET] /api/Verifier/doctors/status/sent
□ [GET] /api/Verifier/doctors/status/under-review
□ [GET] /api/Verifier/doctors/status/verified
□ [GET] /api/Verifier/doctors/status/rejected
□ [GET] /api/Verifier/doctors/{doctorId}/documents
□ [POST] /api/Verifier/documents/{documentId}/approve
□ [POST] /api/Verifier/documents/{documentId}/reject
```
## Missing / Future Mobile Integrations
This section compares currently documented endpoints with anticipated mobile features. Endpoints that exist but aren't fully utilized should be reviewed by the mobile team.