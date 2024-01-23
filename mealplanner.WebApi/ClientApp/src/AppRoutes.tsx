import { Status } from "./pages/Status/status"
import { Recipes } from "./pages/Recipes/recipes"
import { Journey } from "./pages/Journey/journey"
import { Profile } from "./pages/Profile/profile"

import AccountBoxIcon from '@mui/icons-material/AccountBox'
import BookIcon from '@mui/icons-material/Book';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import QueryStatsIcon from '@mui/icons-material/QueryStats';

const AppRoutes = [
  {
    id: 0,
    icon: <AccountBoxIcon />,
    element: <Profile />,
    label: 'Profile',
    path: '/profile',
  },
  {
    id: 1,
    icon: <BookIcon />,
    element: <Journey />,
    label: 'Journey',
    path: '/Journey',
  },
  {
    id: 2,
    icon: <MenuBookIcon />,
    element: <Recipes />,
    label: 'Recipes',
    path: '/recipes',
  },
  {
    id: 3,
    icon: <QueryStatsIcon />,
    element: <Status />,
    label: 'Status',
    path: '/status',
  },
];

export default AppRoutes;
