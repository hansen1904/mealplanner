import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import AccountBoxIcon from '@mui/icons-material/AccountBox'
import BookIcon from '@mui/icons-material/Book';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import QueryStatsIcon from '@mui/icons-material/QueryStats';

const AppRoutes = [
  {
    id: 0,
    icon: <AccountBoxIcon />,
    element: <Home />,
    label: 'Profile',
    path: '/profile',
  },
  {
    id: 1,
    icon: <BookIcon />,
    element: <Counter />,
    label: 'Journey',
    path: '/Journey',
  },
  {
    id: 2,
    icon: <MenuBookIcon />,
    element: <FetchData />,
    label: 'Recipes',
    path: '/recipes',
  },
  {
    id: 3,
    icon: <QueryStatsIcon />,
    element: <FetchData />,
    label: 'Status',
    path: '/status',
  },
];

export default AppRoutes;
