import AccountBoxIcon from '@mui/icons-material/AccountBox'
import BookIcon from '@mui/icons-material/Book';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import QueryStatsIcon from '@mui/icons-material/QueryStats';

const navbarItems = [
    {
        id: 0,
        icon: <AccountBoxIcon />,
        label: 'Profile',
        route: 'profile',
    },
    {
        id: 1,
        icon: <BookIcon />,
        label: 'Journey',
        route: 'journey',
    },
    {
        id: 2,
        icon: <MenuBookIcon />,
        label: 'Recipes',
        route: 'recipes',
    },
    {
        id: 3,
        icon: <QueryStatsIcon />,
        label: 'Status',
        route: 'status',
    },
]

export default navbarItems