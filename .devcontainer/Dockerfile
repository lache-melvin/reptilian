FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# -m creates home folder for reptile
# -s sets shell (bash)
RUN useradd -m -s $(which bash) reptile

# Create workdir /app, give ownership to reptile
# Ownership is preserved when mounting volume to /app
RUN mkdir /app && chown reptile:reptile /app

USER reptile