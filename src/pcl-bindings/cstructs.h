#pragma once

#define MAX_HEADER_FIELDS 8
#define MAX_FIELD_NAME_LENGTH 15

typedef struct
{
    float x;
    float y;
    float z;
    float w;
}eigen_vector4f_t;

typedef struct
{
    float x;
    float y;
    float z;
}eigen_vector3f_t;

typedef struct
{
    int x;
    int y;
    int z;
}eigen_vector3i_t;

typedef struct __pcl_point_field_t
{
    char name[MAX_FIELD_NAME_LENGTH + 1];
    unsigned int offset = 0;
    unsigned char datatype = 0;
    unsigned int count = 0;

}pcl_point_field_t;

typedef struct __pcd_header_t
{
    unsigned int width;
    unsigned int height;
    pcl_point_field_t fields[MAX_HEADER_FIELDS];
    unsigned int point_step;
    unsigned int row_step;
    unsigned int is_dense;
    unsigned int data_type;
    unsigned int data_idx;
}pcd_header_t;