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
    TextInput
} from 'react-admin';

const ReviewFilter = props => (
    <Filter {...props} >
        <NumberInput label="Id" source="id" />
    </Filter>
);

export const ReviewList = props => {
    return (
        <List {...props} filters={<ReviewFilter />} sort={{ field: 'id', order: 'ASC' }}>
            <Datagrid>
                <NumberField source="id" />
                <ImageField source="imageLink" label="Image" title="no_image" />
                <TextField source="imageLink" />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    );
}

export const ReviewEdit = props => {
    return (
        <Edit {...props} mutationMode="pessimistic">
            <SimpleForm>
                <NumberField source="id" />
                <ImageField source="imageLink" label="Image" title="no_image" />
                <TextInput source="imageLink" fullWidth multiline />
            </SimpleForm>
        </Edit>
    );
}

export const ReviewCreate = props => {
    return (
        <Create {...props}>
            <SimpleForm>
                <TextInput source="imageLink" fullWidth multiline />
            </SimpleForm>
        </Create>
    );
}