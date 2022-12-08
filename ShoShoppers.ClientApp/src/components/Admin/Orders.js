import React from 'react';
import {
    DateTimeInput,
    DateField,
    Create,
    Datagrid,
    DeleteButton,
    Edit,
    EditButton,
    Filter,
    List,
    NumberField,
    NumberInput,
    SimpleForm,
    TextField,
    TextInput,
    BooleanField,
    BooleanInput
} from 'react-admin';

const OrderFilter = props => (
    <Filter {...props} >
        <NumberInput label="Id" source="id" />
        <DateTimeInput label="DateOfOrder" source="dateOfOrder" />
        <DateTimeInput label="DateToFinishOrderAndDiliver" source="dateToFinishOrderAndDiliver" />
        <TextInput label="UserItems" source="userItems" />
        <TextInput label="UserEmail" source="userEmail" />
        <TextInput label="UserName" source="userName" />
        <TextInput label="UserSurname" source="userSurname" />
        <TextInput label="PostOffice" source="postOffice" />
        <TextInput label="UserPhoneNumber" source="userPhoneNumber" />
        <BooleanInput label="IsOrderDone" source="isOrderDone" />
        <NumberInput label="OrderPrice" source="orderPrice" />
        <TextInput label="UserUniqueToken" source="userUniqueToken" fullWidth multiline />
    </Filter>
);

export const OrderList = props => {
    return (
        <List {...props} filters={<OrderFilter />} sort={{ field: 'id', order: 'ASC' }}>
            <Datagrid>
                <NumberField source="id" />
                <DateField source="dateOfOrder" showTime={true} />
                <DateField source="dateToFinishOrderAndDiliver" showTime={true} />
                <TextField source="userItems" />
                <TextField source="userEmail" />
                <TextField source="userName" />
                <TextField source="userSurname" />
                <TextField source="postOffice" />
                <TextField source="userPhoneNumber" />
                <BooleanField source="isOrderDone" />
                <NumberField source="orderPrice" />
                <TextField source="userUniqueToken" />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    );
}

export const OrderEdit = props => {
    return (
        <Edit {...props} mutationMode="pessimistic">
            <SimpleForm>
                <NumberField source="id" />
                <DateField label="DateOfOrder" source="dateOfOrder" showTime={true} />
                <DateTimeInput label="DateToFinishOrderAndDiliver" source="dateToFinishOrderAndDiliver" />
                <TextInput label="UserItems" source="userItems" fullWidth multiline />
                <TextInput label="UserEmail" source="userEmail" fullWidth multiline />
                <TextInput label="UserName" source="userName" fullWidth multiline />
                <TextInput label="UserSurname" source="userSurname" fullWidth multiline />
                <TextInput label="PostOffice" source="postOffice" fullWidth multiline />
                <TextInput label="UserPhoneNumber" source="userPhoneNumber" fullWidth multiline />
                <BooleanInput label="IsOrderDone" source="isOrderDone" defaultValue={false} />
                <NumberInput label="OrderPrice" source="orderPrice" />
                <TextField label="UserUniqueToken" source="userUniqueToken" fullWidth multiline />
            </SimpleForm>
        </Edit>
    );
}

export const OrderCreate = props => {
    return (
        <Create {...props}>
            <SimpleForm>
                <DateTimeInput label="DateOfOrder" source="dateOfOrder" />
                <DateTimeInput label="DateToFinishOrderAndDiliver" source="dateToFinishOrderAndDiliver" />
                <TextInput label="UserItems" source="userItems" fullWidth multiline />
                <TextInput label="UserEmail" source="userEmail" fullWidth multiline />
                <TextInput label="UserName" source="userName" fullWidth multiline />
                <TextInput label="UserSurname" source="userSurname" fullWidth multiline />
                <TextInput label="PostOffice" source="postOffice" fullWidth multiline />
                <TextInput label="UserPhoneNumber" source="userPhoneNumber" fullWidth multiline />
                <BooleanInput label="IsOrderDone" source="isOrderDone" defaultValue={false} />
                <NumberInput label="OrderPrice" source="orderPrice" />
                <TextInput label="UserUniqueToken" source="userUniqueToken" />
            </SimpleForm>
        </Create>
    );
}