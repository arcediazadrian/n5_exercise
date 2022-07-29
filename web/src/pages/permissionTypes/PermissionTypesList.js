import { Typography } from '@mui/material';
import { Box } from '@mui/system';

import React from "react";

function PermissionTypesList({permissions}) {

  return (
    <Box>
      {permissions.map(permission => (
          <div key={permission.grantedDate}>
            <Typography variant="h1" component="h2">
              {`${permission.employeeFirstName} ${permission.employeeLastName}`}
            </Typography>
          </div>
        ))}
    </Box>
  );
}

export default PermissionTypesList;
