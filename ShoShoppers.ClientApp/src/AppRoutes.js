import { IndividualDesigns } from "./components/IndividualDesignsPage/IndividualDesigns";
import { Shoppers } from "./components/ShoppersPage/Shoppers";
import { Pins } from "./components/PinsPage/Pins";
import { OrdersPage } from "./components/OrdersPage/OrdersPage";
import { AdminShoppers } from "./components/Admin/AdminShoppers";
import { Home } from "./components/Home";
import { PageNotFound } from "./components/PageNotFound/PageNotFound";

const AppRoutes = [
    {
        path: '/',
        element: <Home />
    },
    {
        path: '/individual',
        element: <IndividualDesigns />
    },
    {
        path: '/shoppers',
        element: <Shoppers />
    },
    {
        path: '/pins',
        element: <Pins />
    },
    {
        path: '/order',
        element: <OrdersPage />
    },
    {
        path: '/admin/*',
        element: <AdminShoppers />
    },
    {
        path: '*',
        element: <PageNotFound />
    }
];

export default AppRoutes;
