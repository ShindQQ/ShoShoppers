import React from 'react';
import {
    Create,
    Datagrid,
    DeleteButton,
    Edit,
    EditButton,
    EmailField,
    Filter,
    List,
    NumberField,
    NumberInput,
    SimpleForm,
    TextInput,
    TopToolbar,
    useDataProvider,
    CreateButton,
    ExportButton,
    Form
} from 'react-admin';

export const SendEmails = () => {
    const dataProvider = useDataProvider();
    return (
        <Form>
            <span className="w-full flex flex-col justify-center p-10">
                <TextInput id="subject" label="Subject" source="subject" fullWidth multiline resettable />
                <TextInput id="htmlBody" label="HtmlBody" source="htmlBody" fullWidth multiline resettable />
                <button className="flex justify-center text-center items-center m-[3px] text-blue-700 font-normal hover:bg-sky-100 duration-200 w-32 rounded-sm" label="SendEmails" onClick={() => dataProvider.sendEmails(document.getElementById("subject").textContent, document.getElementById("htmlBody").textContent)} >
                    <svg className="h-4 w-8 text-blue-700 " fill="currentColor" viewBox="0 0 122.88 88.86" aria-hidden="true">
                        <path fillRule="evenodd"
                            d="M7.05,0H115.83a7.07,7.07,0,0,1,7,7.05V81.81a7,7,0,0,1-1.22,4,2.78,2.78,0,0,1-.66,1,2.62,2.62,0,0,1-.66.46,7,7,0,0,1-4.51,1.65H7.05a7.07,7.07,0,0,1-7-7V7.05A7.07,7.07,0,0,1,7.05,0Zm-.3,78.84L43.53,40.62,6.75,9.54v69.3ZM49.07,45.39,9.77,83.45h103L75.22,45.39l-11,9.21h0a2.7,2.7,0,0,1-3.45,0L49.07,45.39Zm31.6-4.84,35.46,38.6V9.2L80.67,40.55ZM10.21,5.41,62.39,47.7,112.27,5.41Z"
                            clipRule="evenodd" />
                    </svg>
                    <p>SENDEMAILS</p>
                </button>
            </span>
        </Form>
    );
};

const EmailFilter = props => (
    <Filter {...props} >
        <NumberInput label="Id" source="id" />
        <TextInput label="Email" source="mail" />
    </Filter>
);

const EmailsListActions = () => (
    <TopToolbar>
        <EmailFilter context="button" />
        <CreateButton />
        <ExportButton />
        <button className="flex justify-center text-center items-center m-[3px] text-blue-700 font-normal hover:bg-sky-100 duration-200 w-36 h-6 rounded-sm">
            <svg className="h-4 w-8 text-blue-700 " fill="currentColor" viewBox="0 0 122.88 88.86" aria-hidden="true">
                <path fillRule="evenodd"
                    d="M7.05,0H115.83a7.07,7.07,0,0,1,7,7.05V81.81a7,7,0,0,1-1.22,4,2.78,2.78,0,0,1-.66,1,2.62,2.62,0,0,1-.66.46,7,7,0,0,1-4.51,1.65H7.05a7.07,7.07,0,0,1-7-7V7.05A7.07,7.07,0,0,1,7.05,0Zm-.3,78.84L43.53,40.62,6.75,9.54v69.3ZM49.07,45.39,9.77,83.45h103L75.22,45.39l-11,9.21h0a2.7,2.7,0,0,1-3.45,0L49.07,45.39Zm31.6-4.84,35.46,38.6V9.2L80.67,40.55ZM10.21,5.41,62.39,47.7,112.27,5.41Z"
                    clipRule="evenodd" />
            </svg>
            <a href="/admin/send">SENDEMAILS</a>
        </button>
    </TopToolbar>
);

export const EmailList = props => {
    return (
        <List {...props} filters={<EmailFilter />} sort={{ field: 'id', order: 'ASC' }} actions={<EmailsListActions />}>
            <Datagrid>
                <NumberField source="id" />
                <EmailField source="mail" />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    );
}

export const EmailEdit = props => {
    return (
        <Edit {...props} mutationMode="pessimistic">
            <SimpleForm>
                <EmailField source="mail" />
            </SimpleForm>
        </Edit>
    );
}


export const EmailCreate = props => {
    return (
        <Create {...props}>
            <SimpleForm>
                <TextInput source="mail" />
            </SimpleForm>
        </Create>
    );
}