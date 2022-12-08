import React from 'react';
import { Admin, Resource, CustomRoutes } from 'react-admin';
import { IndividualDesignCreate, IndividualDesignEdit, IndividualDesignList } from './IndividualDesigns'
import { PinCreate, PinEdit, PinList } from './Pin'
import { ShopperCreate, ShopperEdit, ShopperList } from './Shopper'
import { ReviewCreate, ReviewEdit, ReviewList } from './Review'
import { EmailCreate, EmailEdit, EmailList, SendEmails } from './Email'
import { OrderCreate, OrderEdit, OrderList } from './Orders'
import { authProvider } from './authProvider'
import { dataProvider } from './dataProvider'
import { Route } from 'react-router-dom';

export const AdminShoppers = () => {
    return (
        <Admin basename="/admin" authProvider={authProvider} dataProvider={dataProvider}>
            <Resource name='IndividualDesign' list={IndividualDesignList} edit={IndividualDesignEdit} create={IndividualDesignCreate} />
            <Resource name='Pin' list={PinList} edit={PinEdit} create={PinCreate} />
            <Resource name='Shopper' list={ShopperList} edit={ShopperEdit} create={ShopperCreate} />
            <Resource name='Review' list={ReviewList} edit={ReviewEdit} create={ReviewCreate} />
            <Resource name='Email' list={EmailList} edit={EmailEdit} create={EmailCreate} />
            <Resource name='Order' list={OrderList} edit={OrderEdit} create={OrderCreate} />
            <CustomRoutes>
                <Route path="/send" element={<SendEmails />} />
            </CustomRoutes>
        </Admin>
    );
}