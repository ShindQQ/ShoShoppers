import React from 'react';
import {
    Create,
    Datagrid,
    DeleteButton,
    Edit,
    EditButton,
    Filter,
    ImageField,
    List,
    NumberField,
    NumberInput,
    SimpleForm,
    TextField,
    TextInput,
    BooleanField,
    BooleanInput
} from 'react-admin';

const PinFilter = props => (
    <Filter {...props} >
        <NumberInput label="Id" source="id" />
        <TextInput label="Name" source="name" />
        <TextInput label="Description" source="description" />
        <NumberInput label="Price" source="price" />
        <TextInput label="Color" source="color" />
        <TextInput label="ImageColor" source="imageColor" />
        <NumberInput label="ItemAmmount" source="itemAmmount" />
        <BooleanInput label="ItemInProduction" source="itemInProduction" />
    </Filter>
);

export const PinList = props => {
    return (
        <List {...props} filters={<PinFilter />} sort={{ field: 'id', order: 'ASC' }}>
            <Datagrid>
                <NumberField source="id" />
                <TextField source="name" />
                <TextField source="description" />
                <NumberField source="price" />
                <TextField source="color" />
                <TextField source="imageColor" />
                <ImageField source="imageLink" label="Image" title="no_image" />
                <TextField source="imageLink" />
                <NumberField source="itemAmmount" />
                <BooleanField source="itemInProduction" />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    );
}

export const PinEdit = props => {
    return (
        <Edit {...props} mutationMode="pessimistic">
            <SimpleForm>
                <NumberField source="id" />
                <ImageField source="imageLink" label="Image" title="no_image" />
                <TextInput source="name" fullWidth multiline />
                <TextInput source="description" fullWidth multiline />
                <NumberInput source="price" />
                <TextInput source="color" fullWidth multiline />
                <TextInput source="imageColor" fullWidth multiline />
                <TextInput source="imageLink" fullWidth multiline />
                <NumberInput source="itemAmmount" />
                <BooleanInput source="itemInProduction" defaultValue={false} />
            </SimpleForm>
        </Edit>
    );
}

export const PinCreate = props => {
    return (
        <Create {...props}>
            <SimpleForm>
                <TextInput source="name" fullWidth multiline />
                <TextInput source="description" fullWidth multiline />
                <NumberInput source="price" />
                <TextInput source="color" fullWidth multiline />
                <TextInput source="imageColor" fullWidth multiline />
                <TextInput source="imageLink" fullWidth multiline />
                <NumberInput source="itemAmmount" />
                <BooleanInput source="itemInProduction" defaultValue={false} />
            </SimpleForm>
        </Create>
    );
}